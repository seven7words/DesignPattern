using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public  interface IAttrStrategy
 {
     int GetExtralHPValue(int lv);
     int GetDmgDescValue(int lv);
     int GetCritDmg(float critRate);
}

