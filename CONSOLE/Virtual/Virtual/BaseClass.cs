using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// For 1 class Animal, 
/// class Dog inheritance class Animal, class Pig inheritance class Animal
/// (vi cho va lon deu thuoc lop dong vat)
/// Ta khai bao 1 virtual Move thuoc class Animal
/// (vi dong vat nao cung co kha nang di chuyen)
/// trong class Dog va Pig ta dinh nghia lai cach di chuyen bang Override
/// 
/// </summary>

namespace Virtual
{
    class BaseClass
    {
        /// <summary>
        ///  virtual auto-implemented property. Overrides can only
        ///  provide specialized behavior if they implement get and set accessors.
        /// </summary>
        public virtual string Name { get; set; }

        // ordinary virtual property with backing field
        private int num;
        public virtual int Number
        {
            get { return num; }
            set { num = value; }
        }
    }
}
