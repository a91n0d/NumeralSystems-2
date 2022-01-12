using System;
using System.Text;

namespace NumeralSystems
{
    public static class Converter
    {
        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the octal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the octal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveOctal(this int number) =>
            number < 0 ? throw new ArgumentException("number is less than zero.", nameof(number))
            : number.GetRadix(8);

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the decimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the decimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveDecimal(this int number) =>
            number < 0 ? throw new ArgumentException("number is less than zero.", nameof(number))
            : number.GetRadix(10);

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the hexadecimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the hexadecimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveHex(this int number) =>
            number < 0 ? throw new ArgumentException("number is less than zero.", nameof(number))
            : number.GetRadix(16);

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveRadix(this int number, int radix) =>
            number < 0 ? throw new ArgumentException("number is less than zero.", nameof(number))
            : number.GetRadix(radix);

        /// <summary>
        /// Gets the value of a signed integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        public static string GetRadix(this int number, int radix)
        {
            if (radix != 8 && radix != 10 && radix != 16)
            {
                throw new ArgumentException("radix is not equal 8, 10 or 16.", nameof(radix));
            }

            StringBuilder sb = new StringBuilder();
            uint unumber = (number >= 0) ? (uint)number : (uint)(number + Math.Pow(2, 32));
            while (unumber != 0)
            {
                int dijit = (int)(unumber % radix);
                dijit = (dijit > 9) ? (55 + dijit) : (48 + dijit);
                sb.Insert(0, (char)dijit);
                unumber /= (uint)radix;
            }

            return sb.ToString();
        }
    }
}
