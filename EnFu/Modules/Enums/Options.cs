using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnFu.Modules.Enums
{
    public class Option
    {
        public int Key { get; set; }
        public string Name { get; set; }
    }
    public class DocumentOptions
    {
        // Common
        public IEnumerable<Option> YesNoOptions
        {
            get
            {
                return new List<Option>
                {
                    {new Option { Key =1, Name="Yes"} },
                    {new Option { Key =2, Name="No"} },
                };
            }
        }
        public IEnumerable<Option> SundayServeTypeOptions
        {
            get
            {
                return new List<Option>
                {
                    {new Option { Key =1, Name="讲员"} },
                    {new Option { Key =2, Name="主席"} },
                    {new Option { Key =3, Name="领诗"} },
                    {new Option { Key =4, Name="司琴"} },
                    {new Option { Key =5, Name="音响"} },
                    {new Option { Key =6, Name="司事"} },
                    {new Option { Key =7, Name="后勤"} },
                    {new Option { Key =8, Name="财务"} },
                    {new Option { Key =9, Name="儿主"} },
                    {new Option { Key =10, Name="青少"} },
                    {new Option { Key =11, Name="新人"} },
                };
            }
        }        
    }
}