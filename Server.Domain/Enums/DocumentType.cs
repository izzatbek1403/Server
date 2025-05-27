namespace Server.Domain.Enums
{
    public enum DocumentType
    {
        None = 0,                    // Belge türü belirtilmemiş
        Sale = 1,                    // Satış
        SaleReturn = 2,              // Satış İadesi
        Buy = 3,                     // Alış (Satın Alma)
        BuyReturn = 4,               // Alış İadesi
        Move = 5,                    // Devir/Hareket (Transfer)
        MoveReturn = 6,              // Hareket İadesi
        WriteOff = 7,                // Rekötür (Zayi, fire)
        UserStockEdit = 8,           // Kullanıcı Stok Düzenleme
        Inventory = 9,               // Sayım
        InventoryAct = 10,           // Sayım Tutanağı
        CafeOrder = 11,              // Kafe Sipariş
        ClientOrder = 12             // Müşteri Sipariş (E-ticaret için önemli!)
    }
}
