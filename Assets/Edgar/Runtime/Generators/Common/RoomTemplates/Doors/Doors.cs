﻿using System;
using System.Collections.Generic;
using Edgar.GraphBasedGenerator.Grid2D;
using UnityEngine;

namespace Edgar.Unity
{
    /// <summary>
    ///     Doors MonoBehaviour that is used to define doors for room templates.
    /// </summary>
    [ExecuteInEditMode]
    public class Doors : MonoBehaviour
    {
        [HideInInspector]
        public int DistanceFromCorners = 1;

        [HideInInspector]
        public int DoorLength = 1;

        public List<Door> DoorsList = new List<Door>();

        [HideInInspector]
        public DoorMode SelectedMode;

        public IDoorModeGrid2D GetDoorMode()
        {
            if (SelectedMode == DoorMode.Manual)
            {
                var doors = new List<DoorGrid2D>();

                foreach (var door in DoorsList)
                {
                    var doorLine = new DoorGrid2D(door.From.RoundToUnityIntVector3().ToCustomIntVector2(),
                        door.To.RoundToUnityIntVector3().ToCustomIntVector2()); // TODO: ugly

                    doors.Add(doorLine);
                }

                return new ManualDoorModeGrid2D(doors);
            }

            if (SelectedMode == DoorMode.Simple)
            {
                return new SimpleDoorModeGrid2D(DoorLength - 1, DistanceFromCorners);
            }

            throw new ArgumentException("Invalid door mode selected");
        }

        public enum DoorMode
        {
            Simple = 0,
            Manual = 1,
        }
    }
}