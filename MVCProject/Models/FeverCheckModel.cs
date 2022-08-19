using System.Diagnostics;
using System.Globalization;

namespace MVCProject.Models
{
    public class FeverCheckModel
    {
        public static string CheckTemperature(string temp)
        {
            Debug.WriteLine("temperature = " + temp);
            float temperature = float.Parse(temp, CultureInfo.InvariantCulture.NumberFormat);
            if (temperature > 35 && temperature < 37.5)
            {
                return "You have no fever!";
            }
            else
            {
                if (temperature <= 35)
                {
                    return "You have hypothermia. Get help!";
                }
                else
                {
                    return "You have fever. Go to bed!";
                }
            }
        }
    }
}
