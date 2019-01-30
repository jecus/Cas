using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace CASTerms
{
    /// <summary>
    /// Позволяет извлекать серийные номера устроиств, подключенных к USB
    /// </summary>
    public class USBSerialNumberManager
    {
        string _serialNumber;
        string _driveLetter;

        /// <summary>
        /// Возвращает серийный номер USB устроиства, помеченного определенной литерой
        /// </summary>
        /// <param name="driveLetter">Литера устроиства ("F:\", "G:\" или другая)</param>
        /// <returns>серийный номер устроиста ввиде строки или "" если такого устроиства нет</returns>
        public string getSerialNumberFromDriveLetter(string driveLetter)
        {
            _driveLetter = driveLetter.ToUpper();

            if (!_driveLetter.Contains(":"))
            {
                _driveLetter += ":";
            }

            MatchDriveLetterWithSerial();

            return _serialNumber;
        }

        private void MatchDriveLetterWithSerial()
        {

            string[] diskArray;
            string driveNumber;
            string driveLetter;

            ManagementObjectSearcher searcher1 = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDiskToPartition");
            foreach (ManagementObject dm in searcher1.Get())
            {
                driveLetter = getValueInQuotes(dm["Dependent"].ToString());
                diskArray = getValueInQuotes(dm["Antecedent"].ToString()).Split(',');
                driveNumber = diskArray[0].Remove(0, 6).Trim();
                if (driveLetter == _driveLetter)
                {
                    /* This is where we get the drive serial */
                    ManagementObjectSearcher disks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                    foreach (ManagementObject disk in disks.Get())
                    {

                        if (disk["Name"].ToString() == ("\\\\.\\PHYSICALDRIVE" + driveNumber) & disk["InterfaceType"].ToString() == "USB")
                        {
                            _serialNumber = parseSerialFromDeviceID(disk["PNPDeviceID"].ToString());
                        }
                    }
                }
            }
        }

        private string parseSerialFromDeviceID(string deviceId)
        {
            string[] splitDeviceId = deviceId.Split('\\');
            string[] serialArray;
            string serial;
            int arrayLen = splitDeviceId.Length - 1;

            serialArray = splitDeviceId[arrayLen].Split('&');
            serial = serialArray[0];

            return serial;
        }

        private string getValueInQuotes(string inValue)
        {
            int posFoundStart = inValue.IndexOf("\"");
            int posFoundEnd = inValue.IndexOf("\"", posFoundStart + 1);

            string parsedValue = inValue.Substring(posFoundStart + 1, (posFoundEnd - posFoundStart) - 1);

            return parsedValue;
        }
    }
}
