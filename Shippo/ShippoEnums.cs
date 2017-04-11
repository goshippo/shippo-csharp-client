using System;
namespace Shippo
{
    public static class ShippoEnums
    {
        public enum LabelFiletypes { NONE, PNG, PDF, PDF_4x6, ZPLII }
        public enum Statuses { VALIDATING, VALID, INVALID, PURCHASING, PURCHASED }
        public enum ObjectResults { none, creation_failed, creation_succeeded, purchase_failed, purchase_succeeded }
        public enum TrackingStatus { UNKNOWN, DELIVERED, TRANSIT, FAILURE, RETURNED }
    }
}
