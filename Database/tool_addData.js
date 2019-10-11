function add_Header_ThucHienHangNgay(session,date){
    let result ="insert into header_ThucHienTheoNgay(MaPhongBan,Ngay,Ca) VALUES \n"
    for(let i = 1 ; i <= 11 ; i++) {
        result+="('PXKT"+i+"',"+"'"+date+"',"+session+"),\n"
    }
    //
    for(let i = 1 ; i <= 8 ; i++) {
        if (i!=4 && i!=6){
            result+="('PXDL"+i+"',"+"'"+ date+"',"+session+"),\n"
        }
    }
    result += "('KCS','"+date+"',"+session+"),\n"
    result += "('PXST','"+date+"',"+session+"),\n"
    result += "('CTYDH','"+date+"',"+session+")\n"
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

startPoint = 480;
inserthihi = "insert into ChiTiet_ThucHien_TieuChi_TheoNgay(HeaderID,MaTieuChi,SanLuong) VALUES";
while (startPoint <=940){
    for (let i = 1 ; i <= 22; i++){
        switch(i){
            // px khai thac
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                for(let j=0; j<=10;j++){
                    inserthihi += "("+(startPoint+j)+","+i+","+Math.ceil(100+Math.random()*900)+"),\n"
                }
                break;
            //px dao lo
            case 6:
            case 7:
            case 9:
            case 19:
                for(let j=11; j<=16;j++){
                    inserthihi += "("+(startPoint+j)+","+i+","+Math.ceil(100+Math.random()*900)+"),\n"
                }
                break;
            // phong kcs
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 22:
                    inserthihi += "("+(startPoint+17)+","+i+","+Math.ceil(100+Math.random()*900)+"),\n"
                break;
            // PXST
            case 21:
                    inserthihi += "("+(startPoint+18)+","+i+","+Math.ceil(100+Math.random()*900)+"),\n"
                break;
            // nhap Duong Huy
            case 19:
                    inserthihi += "("+(startPoint+19)+","+i+","+Math.ceil(100+Math.random()*900)+"),\n"
                break;
        }
    }
    startPoint += 20;
}

console.log(inserthihi)