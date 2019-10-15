function add_Header_ThucHienHangNgay(session,date){
    let result =""
    // pxkt
    for(let i = 1 ; i <= 11 ; i++) {
        result += "insert into header_ThucHienTheoNgay(MaPhongBan,Ngay,Ca) VALUES \n"
        result+="('PXKT"+i+"',"+"'"+date+"',"+session+")\n GO \n"
    }
    // pxdl
    for(let i = 1 ; i <= 8 ; i++) {
        if (i!=4 && i!=6){
            result += "insert into header_ThucHienTheoNgay(MaPhongBan,Ngay,Ca) VALUES \n"
            result+="('PXDL"+i+"',"+"'"+ date+"',"+session+")\n GO \n"
        }
    }
    // kcs
    result += "insert into header_ThucHienTheoNgay(MaPhongBan,Ngay,Ca) VALUES \n"
    result += "('KCS','"+date+"',"+session+")\n GO \n"
    // pxst
    result += "insert into header_ThucHienTheoNgay(MaPhongBan,Ngay,Ca) VALUES \n"
    result += "('PXST','"+date+"',"+session+")\n GO \n"
    // Duong Huy
    result += "insert into header_ThucHienTheoNgay(MaPhongBan,Ngay,Ca) VALUES \n"
    result += "('CTYDH','"+date+"',"+session+")\n GO \n"
    // Lo Thien
    result += "insert into header_ThucHienTheoNgay(MaPhongBan,Ngay,Ca) VALUES \n"
    result += "('PXLT','"+date+"',"+session+")\n GO \n"
    return result
}

insertDB = ""

for (let i = 1 ; i <= 10; i++){
    if (i !=6 && i!=7){
        date = "2019-09-" +i
        for (let j = 1; j <=3 ;j++){
            insertDB += add_Header_ThucHienHangNgay(j,date) + "\n"
        }
    }
}

startPoint = 1;
query = "";
while (startPoint <=484){
    for (let i = 0 ; i <= 10 ;i++) {
            // than khai thac
            query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
            query += "("+(startPoint)+","+(2)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+") \n"
            // than ML DAO
            query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
            query += "("+(startPoint)+","+(7)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+")\n"
            // than ML NEO
            query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
            query += "("+(startPoint)+","+(9)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+")\n"
            // than ML XEN
            query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
            query += "("+(startPoint)+","+(19)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+")\n"
            startPoint++;
    }
    //
    for (let i = 11 ; i <= 16 ;i++){
        // than dao lo
        query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
        query += "("+(startPoint)+","+(1)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+")\n"
        // than ML DAO
        query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
        query += "("+(startPoint)+","+(7)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+")\n"
        // than ML NEO
        query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
        query += "("+(startPoint)+","+(9)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+")\n"
        // than ML XEN
        query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
        query += "("+(startPoint)+","+(19)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+")\n"
        startPoint++;
    }
    // nhap KCS
    for (let i= 18;i <= 30; i++){
        if (i != 19){
            query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
            query += "("+(startPoint)+","+(i)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+")\n"
        }
    }
    startPoint++
    // nhap PXST
    for (let i= 10;i <= 17; i++){
            query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
            query += "("+(startPoint)+","+(i)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+")\n"
    }
    startPoint++
    // Duong Huy
    query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
    query += "("+(startPoint)+","+(6)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+")\n"
    startPoint++
    // PXLT
    query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
    query += "("+(startPoint)+","+(3)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+")\n"
    //
    query += "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong,KeHoach) VALUES \n"
    query += "("+(startPoint)+","+(4)+","+(Math.ceil(100+Math.random()*900))+","+(Math.ceil(100+Math.random()*900))+")\n"
    startPoint++
    
}

console.log(inserthihi)