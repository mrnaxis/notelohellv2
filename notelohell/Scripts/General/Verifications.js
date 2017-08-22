//Basic Affairs of verification - Minifie it!!!!!

function checkCampos(input1, input2, modo) {
    if (input1 !== 'undefined' && input1 !== null) {
        if (modo === 'undefined' || modo === null)
            modo = 0;

        switch (modo) {
            case 0: return input1.val() === input2.val();
            case 1: return input1.val() !== input2.val();
        }
    }
}

function dateValid(inputDate) {
    var dataOficial = inputDate.value.split('/');
    var data = new Date(dataOficial[1] + '/' + dataOficial[0] + '/' + dataOficial[2]);

    if (isNaN(data.getMilliseconds()))
        return false;
    return true;
}