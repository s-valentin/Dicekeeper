﻿using System;
using System.Linq;
using System.Text;
using Edgar.Geometry;
using Edgar.GraphBasedGenerator.Grid2D;
using UnityEngine;

namespace Edgar.Unity.Diagnostics
{
    public static class RoomTemplateDiagnostics
    {
        /// <summary>
        /// Tries to compute a room template from a given game object and returns the result.
        /// </summary>
        /// <param name="roomTemplate"></param>
        /// <returns></returns>
        public static ActionResult CheckAll(GameObject roomTemplate)
        {
            RoomTemplatesLoader.TryGetRoomTemplate(roomTemplate, out var _, out var result);
            return result;
        }

        /// <summary>
        /// Checks that the room template has all the necessary components.
        /// </summary>
        /// <param name="roomTemplate"></param>
        /// <returns></returns>
        public static ActionResult CheckComponents(GameObject roomTemplate)
        {
            var result = new ActionResult();

            if (roomTemplate.GetComponent<RoomTemplateSettings>() == null)
            {
                result.AddError($"The {nameof(RoomTemplateSettings)} component is missing on the room template game object.");
            }

            if (roomTemplate.GetComponent<Doors>() == null)
            {
                result.AddError($"The {nameof(Doors)} component is missing on the room template game object.");
            }

            return result;
        }

        /// <summary>
        /// Checks the doors of the room template.
        /// </summary>
        /// <param name="outline"></param>
        /// <param name="doorMode"></param>
        /// <returns></returns>
        public static ActionResult CheckDoors(PolygonGrid2D outline, IDoorModeGrid2D doorMode)
        {
            var result = new ActionResult();

            try
            {
                var doors = doorMode.GetDoors(outline);

                if (doors.Count == 0)
                {
                    if (doorMode is SimpleDoorModeGrid2D)
                    {
                        result.AddError($"The simple door mode is used but there are no valid door positions. Try to decrease door length and/or corner distance.");
                    }
                    else
                    {
                        result.AddError($"The manual door mode is used but no doors were added.");
                    }
                }
            }
            // TODO: this is not optimal - the argument exception might be something different than invalid manual doors
            catch (ArgumentException e)
            {
                if (doorMode is ManualDoorModeGrid2D)
                {
                    result.AddError($"It seems like some of the manual doors are not located on the outline of the room template.");
                }
                else
                {
                    result.AddError(e.Message);
                }
            }

            return result;
        }

        /// <summary>
        /// Checks the doors of the room template.
        /// </summary>
        /// <param name="roomTemplate"></param>
        /// <returns></returns>
        public static ActionResult CheckDoors(GameObject roomTemplate)
        {
            var roomTemplateSettings = roomTemplate.GetComponent<RoomTemplateSettings>();
            var outline = roomTemplateSettings.GetOutline();
            var doors = roomTemplate.GetComponent<Doors>();

            if (doors == null)
            {
                var result = new ActionResult();
                result.AddError($"The {nameof(Doors)} component is missing on the room template game object.");
                return result;
            }

            var doorMode = doors.GetDoorMode();

            return CheckDoors(outline, doorMode);
        }

        public static ActionResult CheckWrongManualDoors(PolygonGrid2D outline, IDoorModeGrid2D doorMode, out int differentLengthsCount)
        {
            var result = new ActionResult();
            differentLengthsCount = -1;

            if (doorMode is ManualDoorModeGrid2D)
            {
                var doors = doorMode.GetDoors(outline);
                var differentLengths = doors.Select(x => x.Length).Distinct().ToList();
                differentLengthsCount = differentLengths.Count;

                if (differentLengthsCount >= 3)
                {
                    result.AddError($"There are {differentLengthsCount} different lengths of manual doors. Please make sure that this is intentional. This is often caused by an incorrect use of the manual door (see the warning in the Doors component).");
                }
            }

            return result;
        }

        public static ActionResult CheckWrongManualDoors(GameObject roomTemplate, out int differentLengthsCount)
        {
            var roomTemplateSettings = roomTemplate.GetComponent<RoomTemplateSettings>();
            var outline = roomTemplateSettings.GetOutline();
            var doors = roomTemplate.GetComponent<Doors>();
            var doorMode = doors.GetDoorMode();

            return CheckWrongManualDoors(outline, doorMode, out differentLengthsCount);
        }
    }
}