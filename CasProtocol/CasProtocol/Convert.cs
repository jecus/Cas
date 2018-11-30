namespace CasProtocol
{
    using System;

    public static class Convert
    {
        public static string DateTimeToString(DateTime dateTime)
        {
            return (dateTime.Day.ToString() + "." + dateTime.Month.ToString() + "." + dateTime.Year.ToString() + " " + dateTime.Hour.ToString() + ":" + dateTime.Minute.ToString() + ":" + dateTime.Second.ToString());
        }

        public static DateTime StringToDateTime(string s)
        {
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            string[] strArray = s.Split(new char[] { '.', ' ', ':' });
            if ((((strArray.Length == 6) && int.TryParse(strArray[0], out num)) && (int.TryParse(strArray[1], out num2) && int.TryParse(strArray[2], out num3))) && ((int.TryParse(strArray[3], out num4) && int.TryParse(strArray[4], out num5)) && int.TryParse(strArray[5], out num6)))
            {
                return new DateTime(num3, num2, num, num4, num5, num6);
            }
            return DateTime.Now;
        }
    }
}

