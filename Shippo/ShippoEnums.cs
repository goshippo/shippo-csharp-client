using System;
namespace Shippo
{
    public static class ShippoEnums
    {
        public enum LabelFiletypes { PNG, PDF, PDF_4X6, ZPLII }
        public enum ObjectStatuses { VALIDATING, VALID, INVALID, PURCHASING, PURCHASED }
        public enum ObjectResults { CREATION_FAILED, CREATION_SUCCEEDED, PURCHASE_FAILED, PURCHASE_SUCCEEDED, ANY }
    }
}
