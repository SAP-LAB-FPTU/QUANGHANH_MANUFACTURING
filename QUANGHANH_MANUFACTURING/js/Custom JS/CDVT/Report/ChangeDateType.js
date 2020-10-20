window.onload = function () {

    //Get a reference to the link on the page
    // with an id of "mylink"
    var a = document.getElementById("day");
    var b = document.getElementById("month");
    var c = document.getElementById("quarter");
    var d = document.getElementById("year");

    //Set code to run when the link is clicked
    // by assigning a function to "onclick"
    a.onclick = function () {
        $("#type").html("Xem Theo Ngày");
        document.getElementsByClassName("month")[0].style.display = "none";
        document.getElementsByClassName("quarter")[0].style.display = "none";
        document.getElementsByClassName("year")[0].style.display = "none";
        document.getElementsByClassName("day")[0].style.display = "block";
        $('.dropdown-trigger').dropdown('close');
        return false;
    }

    b.onclick = function () {
        $("#type").html("Xem Theo Tháng");
        document.getElementsByClassName("day")[0].style.display = "none";
        document.getElementsByClassName("quarter")[0].style.display = "none";
        document.getElementsByClassName("year")[0].style.display = "none";
        document.getElementsByClassName("month")[0].style.display = "block";
        $('.dropdown-trigger').dropdown('close');
        return false;
    }

    c.onclick = function () {
        $("#type").html("Xem Theo Quý");
        document.getElementsByClassName("day")[0].style.display = "none";
        document.getElementsByClassName("month")[0].style.display = "none";
        document.getElementsByClassName("year")[0].style.display = "none";
        document.getElementsByClassName("quarter")[0].style.display = "block";
        $('.dropdown-trigger').dropdown('close');
        return false;
    }

    d.onclick = function () {
        $("#type").html("Xem Theo Năm");
        document.getElementsByClassName("day")[0].style.display = "none";
        document.getElementsByClassName("month")[0].style.display = "none";
        document.getElementsByClassName("quarter")[0].style.display = "none";
        document.getElementsByClassName("year")[0].style.display = "block";
        $('.dropdown-trigger').dropdown('close');
        return false;
    }
    
}