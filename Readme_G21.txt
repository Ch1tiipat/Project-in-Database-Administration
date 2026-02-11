คู่มือการติดตั้ง
1. รายละเอียดของโครงงาน
1) ออกแบบสร้าง ER Diagram กับ Relational Model ที่ครอบคลุม Wellmeadows requirements ทุกข้อ (a-n) และมอดูลเพิ่มเติม
2) ออกแบบและสร้าง Data Dictionary ที่ครอบคลุมมอดูลทั้ง 4 ที่ทำใน Visual Basic
3) สร้างฐานข้อมูลใน SQL Server Management Studio Management Studio 20 โดยใช้ชื่อฐานข้อมูลว่าWellmeadowsHospital
4) พัฒนาระบบด้วย VB ตามความต้องการของ Wellmeadows ทั้ง 4 มอดูล ดังนี้
4.1 Module 1: Staff (a-c)
4.2 Module 2: Patient Referral (d-h)
4.3 Module 3: Medication (j-k)
4.4 Module 4: Reports and Analytics (มอดูลพิเศษเพิ่มเติมเพื่อการรายงานและการวิเคราะห์ข้อมูล)
2. ระบบนี้ดำเนินการโดยเทคโนโลยีต่อไปนี้ :
1) Microsoft SQL Server Management Studio 18
2) Microsoft Visual Studio 2022
3. วิธีการติดตั้งและใช้งาน
1) ติดตั้ง Microsoft SQL Server Management Studio 20
2) ติดตั้ง Visual Studio 2022
3) จากนั้นทำการ Download File ที่ชื่อ "G21Database" และ "G21_VB" (ทำการ Extract All .. )
4) เมื่อดาวน์โหลดเสร็จ ให้ไปที่ SQL Server Management Studio 18 ทำการเชื่อมกับ Server name ของเราก็ได้ จากนั้นกด Connect
5) เมื่อกดเข้ามาหน้า Server ของเราแล้ว ให้ไปที่ File - Open จากนั้นเลือก File - G21Database จากนั้นกด Open จะปรากฏ Code ขึ้น ให้ทำการเปลี่ยนที่อยู่ไฟล์ให้เป็นที่ อยู่ที่ต้องการจัดเก็บในอุปกรณ์ของเราเอง
(ตรงส่วนของ 
Private Const ConnStr As String =
    "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True" 
จากนั้นกด Execute
6) ทำการเปิดโปรแกรม Visual Studio 2022 ขึ้นมาโดยกดปุ่ม "Launch"
7) เปิด Visual Studio 2022 เลือก "Open a local folder" เลือกไฟล์ Pro73 ที่ได้ทำการ Extract ไว้ จากนั้นกด "select Folder"
8) เมื่อเข้ามาแล้วให้ไปยัง "Solution Explorer" เลือก .Wellmeadowns Hospital.sln"
9) จากนั้นให้ทำการเชื่อมฐานข้อมูลที่ "Connect to Database" ใส่ Server name ของเรา จากนั้นเลือกที่ .Select or enter a database name:" เลือกฐานข้อมูล
"WellmeadownsHospital, dbo" แล้วกด ok
10) กด Start