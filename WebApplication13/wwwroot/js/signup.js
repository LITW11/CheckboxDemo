$(() => {
    $("input").on('input', function () {
        ensureFormValidity();
    });

    //$("form").on('submit', function () {
    //    $("#signup").prop('disabled', false);
    //});

    function isValidNum(num) {
        return num && !isNaN(num) && num > 0;
    }

    $("#color-select").on('change', function () {
        //const select = $("#color-select");
        //console.log(select.val());
        ensureFormValidity();
    });

    $("#age").on('input', function () {
        const age = $("#age").val();
        if (!isValidNum(age)) {
            return;
        }

        if (age >= 50) {
            $("#signup").prop('disabled', true);
            $("#signup").prop('checked', true);
            $("form").append("<input type='hidden' name='signuptonewsletter' value='true' id='chk-hidden' />")
        } else {
            $("#signup").prop('disabled', false);
            $("#chk-hidden").remove();
        }

    });


    function ensureFormValidity() {
        const name = $("#name").val().trim();
        const age = $("#age").val();
        const isAgeValid = isValidNum(age);
        const colorOption = parseInt($("#color-select").val());

        const isValid = name && isAgeValid && colorOption !== -1;
        $(".btn-primary").prop('disabled', !isValid);
    }
})
