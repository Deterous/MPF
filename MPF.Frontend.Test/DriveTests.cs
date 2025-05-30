﻿using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace MPF.Frontend.Test
{
    public class DriveTests
    {
        #region ToInternalDriveType

        /// <summary>
        /// DiscType values that map to InternalDriveType
        /// </summary>
        private static readonly DriveType[] _mappableDriveTypes =
        [
            DriveType.CDRom,
            DriveType.Fixed,
            DriveType.Removable,
        ];

        /// <summary>
        /// Check that every supported DriveType maps to an InternalDriveType
        /// </summary>
        /// <param name="driveType">DriveType value to check</param>
        /// <param name="expectNull">True to expect a null mapping, false otherwise</param>
        [Theory]
        [MemberData(nameof(GenerateDriveTypeMappingTestData))]
        public void ToInternalDriveTypeTest(DriveType driveType, bool expectNull)
        {
            var actual = Drive.ToInternalDriveType(driveType);

            if (expectNull)
                Assert.Null(actual);
            else
                Assert.NotNull(actual);
        }

        /// <summary>
        /// Generate a test set of DriveType values
        /// </summary>
        /// <returns>MemberData-compatible list of DriveType values</returns>
        public static List<object?[]> GenerateDriveTypeMappingTestData()
        {
            var testData = new List<object?[]>() { new object?[] { null, true } };
            foreach (DriveType driveType in Enum.GetValues(typeof(DriveType)))
            {
                if (Array.IndexOf(_mappableDriveTypes, driveType) > -1)
                    testData.Add([driveType, false]);
                else
                    testData.Add([driveType, true]);
            }

            return testData;
        }

        #endregion
    }
}
