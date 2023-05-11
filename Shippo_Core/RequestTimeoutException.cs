using System;

namespace Shippo {
    public class RequestTimeoutException : ShippoException {
        public RequestTimeoutException(string auxMessage) : base(auxMessage, null) {}
    }
}
