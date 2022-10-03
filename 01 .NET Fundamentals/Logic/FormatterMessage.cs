using System;

namespace Logic
{
    public static class FormatterMessage
    {
        public static string HelloWorld(string username)
        {
            var current_time = DateTime.Now;
            return $"{current_time} Hello, {username}!";
        }
    }
}
