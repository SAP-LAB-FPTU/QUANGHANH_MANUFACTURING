var options = document.querySelectorAll('#supplyID option');
var options2 = document.querySelectorAll('#equipAttached option');

function myfunction() {
    var abc = document.getElementsByClassName("temp");
    for (var i = 0; i < abc.length; i++) {
        abc[i].addEventListener('input', function (e) {
            var input = e.target,
                inputValue = input.value;

            for (var i = 0; i < options.length; i++) {
                var option = options[i];

                if (option.value === inputValue) {
                    input.value = option.label;
                    input.id = option.value;
                    break;
                }
            }
        });
    }
}

function myfunction2() {
    var abc = document.getElementsByClassName("temp");
    for (var i = 0; i < abc.length; i++) {
        abc[i].addEventListener('input', function (e) {
            var input = e.target,
                parent = input.parentElement.nextElementSibling,
                inputValue = input.value;

            for (var i = 0; i < options.length; i++) {
                var option = options[i];

                if (option.value === inputValue) {
                    parent.innerHTML = option.label;
                    break;
                }
            }
        });
    }
}

function myfunction3() {
    var abc = document.getElementsByClassName("temp");
    for (var i = 0; i < abc.length; i++) {
        abc[i].addEventListener('input', function (e) {
            var input = e.target,
                parent = input.parentElement.nextElementSibling,
                inputValue = input.value;

            for (var i = 0; i < options2.length; i++) {
                var option = options2[i];

                if (option.value === inputValue) {
                    parent.innerHTML = option.label;
                    break;
                }
            }
        });
    }
}