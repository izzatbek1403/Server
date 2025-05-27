namespace Server.Domain.Enums
{
    public enum PaymentType
    {
        MoneyPayment = 0,            // Nakit
        MoneyDocumentPayment = 1,    // Belge Ödemesi
        MoneyMovement = 2,           // Para Hareketi
        MoneyCorrection = 3,         // Düzeltme
        BonusesDocumentPayment = 4,  // Bonus
        CheckDiscount1 = 5,          // %1 indirim
        CheckDiscount2 = 6,          // %2 indirim
        Prepaid = 7,                 // Ön Ödeme
        Discount = 8                 // İndirim
    }
}
