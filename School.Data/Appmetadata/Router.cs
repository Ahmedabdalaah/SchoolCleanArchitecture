using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Appmetadata
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "Version1";
        public const string Rule=root+"/" + version+"/";
        public static class StudentRouting
        {
            public const string prefix = Rule + "Student";
            public const string list = prefix + "/List";
            public const string getById = prefix + "/{id}";
            public const string create = prefix + "/Create";

        }
    }
}
