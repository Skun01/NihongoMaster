namespace NihongoMaster.Domain.Enums;

public enum SRSStage
{
    New = 0,
    // Beginner (Mới học)
    Beginner1 = 1, // 4h
    Beginner2 = 2, // 8h
    Beginner3 = 3, // 24h
    
    // Adept (Thành thạo)
    Adept1 = 4, // 2d
    Adept2 = 5, // 4d
    
    // Seasoned (Dày dạn)
    Seasoned1 = 6, // 8d
    Seasoned2 = 7, // 14d
    
    // Expert (Chuyên gia)
    Expert1 = 8, // 1m
    Expert2 = 9, // 2m
    
    // Master (Bậc thầy)
    Master = 10, // 4m
    
    // Burned (Đã thuộc lòng - Không bao giờ hỏi lại)
    Burned = 11
}
