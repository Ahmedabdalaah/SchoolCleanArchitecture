namespace School.Data.Appmetadata
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "Version1";
        public const string Rule = root + "/" + version + "/";
        public static class StudentRouting
        {
            public const string prefix = Rule + "Student";
            public const string list = prefix + "/List";
            public const string getById = prefix + "/{id}";
            public const string create = prefix + "/Create";
            public const string edit = prefix + "/Edit";
            public const string delete = prefix + "/Delete/{id}";



        }
    }
}
