using System;

namespace exception
{
    public class BussinesException : Exception
    {
        public BussinesException(String msg) : base(msg){}

    }
}