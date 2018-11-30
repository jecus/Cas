namespace CasProtocol
{
    using System;
    using System.Text;

    public class ClientRequest
    {
        private bool _AbortConnection;
        private byte[] _BinaryRequest;
        private byte[] _BinaryResponse;
        private bool _Handled;

        public bool AbortConnection
        {
            get
            {
                return this._AbortConnection;
            }
            set
            {
                this._AbortConnection = value;
            }
        }

        public byte[] BinaryRequest
        {
            get
            {
                return this._BinaryRequest;
            }
            set
            {
                this._BinaryRequest = value;
            }
        }

        public byte[] BinaryResponse
        {
            get
            {
                return this._BinaryResponse;
            }
            set
            {
                this._BinaryResponse = value;
            }
        }

        public bool Handled
        {
            get
            {
                return this._Handled;
            }
            set
            {
                this._Handled = value;
            }
        }

        public string Request
        {
            get
            {
                if (this._BinaryRequest != null)
                {
                    return Encoding.Unicode.GetString(this._BinaryRequest);
                }
                return string.Empty;
            }
            set
            {
                this._BinaryRequest = Encoding.Unicode.GetBytes(value);
            }
        }

        public string Response
        {
            get
            {
                if (this._BinaryResponse != null)
                {
                    return Encoding.Unicode.GetString(this._BinaryResponse);
                }
                return string.Empty;
            }
            set
            {
                this._BinaryResponse = Encoding.Unicode.GetBytes(value);
            }
        }
    }
}

