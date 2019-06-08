using System;


namespace MaskedDateEntryControl
{
    public class InvalidDateTextEventArgs : EventArgs
    {

        private string _Message = "" 
            + "Định dạng ngày tháng chưa chính xác. "
            + "Vui lòng nhập theo định dạng Ngày/Tháng/Năm.";

        private string _InvalidDateString = "";


        public InvalidDateTextEventArgs(string InvalidDateString) : base()
        {
            _InvalidDateString = InvalidDateString;
        }


        public InvalidDateTextEventArgs(string InvalidDateString, string Message) 
            : this(InvalidDateString)
            {
                _Message = Message;
            }


        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }


        public String InvalidDateString
        {
            get { return _InvalidDateString; }
        }


    }
}
