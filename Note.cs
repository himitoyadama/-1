 public class Note
 {
     [PrimaryKey, AutoIncrement]
     public int ID { get; set; }
     public string Attendant { get; set; } //担当
     public string Customer { get; set; } //お客様
     public int OutstandingFee { get; set; } //未収金
     public int Point { get; set; } //ポイント数
     public DateTime Date { get; set; }
 }
