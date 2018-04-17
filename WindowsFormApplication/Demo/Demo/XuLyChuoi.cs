using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public static class XuLyChuoi
    {
        /// <summary>
        /// Hàm viết hoa toàn bộ chuỗi
        /// </summary>
        /// <param name="input">Chuỗi cần viết hoa</param>
        /// <returns></returns>
        public static string VietHoa(string input)
        {
            return input.ToUpper();
        }

        /// <summary>
        /// Hàm viết hoa kèm với tiền tố
        /// </summary>
        /// <param name="input">Chuỗi cần viết hoa</param>
        /// <param name="pre">Tiền tố</param>
        /// <returns></returns>
        public static string VietHoa(string input, string pre)
        {
            return pre.ToUpper() + ": " + input.ToUpper();
        }
    }
}
