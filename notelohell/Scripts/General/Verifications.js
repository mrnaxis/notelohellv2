//Basic Affairs of verification - Minifie it!!!!!

function checkCampos(input1, input2, modo) {
    if (typeof input1 !== 'undefined' && input1 !== null) {
        if (typeof modo === 'undefined' || modo === null)
            modo = 0;

        switch (modo) {
            case 0: return input1.val() === input2.val();
            case 1: return input1.val() !== input2.val();
            case 2: return (input1.val() !== "");
            case 3: return (input1.val() !== "" && input2.val() !== "");
        }
    }
}
//for dd/mm/yyyy format
function dateValid(inputDate) {
    var dataOficial = inputDate.value.split('/');
    var data = new Date(dataOficial[1] + '/' + dataOficial[0] + '/' + dataOficial[2]);
    var day = data.getDate();
    if (isNaN(data.getMilliseconds()) || day !== Number(dataOficial[0]))
        return false;
    return true;
}