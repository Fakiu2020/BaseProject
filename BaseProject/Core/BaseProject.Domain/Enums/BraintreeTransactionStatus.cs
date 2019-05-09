namespace BaseProject.Domain.Enums
{

    public enum BraintreeTransactionStatus
    {
        AUTHORIZATION_EXPIRED = 1,
        AUTHORIZED = 2,
        AUTHORIZING = 3,
        FAILED = 4,
        GATEWAY_REJECTED = 5,
        PROCESSOR_DECLINED = 6,
        SETTLED = 7,
        SETTLING = 8,
        SUBMITTED_FOR_SETTLEMENT = 9,
        VOIDED = 10,
        UNRECOGNIZED = 11,
        SETTLEMENT_CONFIRMED = 12,
        SETTLEMENT_DECLINED = 13,
        SETTLEMENT_PENDING = 14
    }
}
