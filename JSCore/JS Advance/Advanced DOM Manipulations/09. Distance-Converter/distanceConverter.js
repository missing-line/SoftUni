function attachEventsListeners() {

    let btn = document.getElementById('convert');

    btn.addEventListener('click', function () {
        let value = +document.getElementById('inputDistance').value;

        let units = document.getElementById('inputUnits');
        let index = units.selectedIndex;
        let optionInput = units.children[index].value;

        let outputUnits = document.getElementById('outputUnits');
        let outIndex = outputUnits.selectedIndex;
        let outOption = units.children[outIndex].value;

        if (value) {
            document.getElementById('outputDistance').value = calculate(value, optionInput, outOption);
        }
    });

    function calculate(value, input, output) {
        if (input === 'km') {
            switch (output) {
                case 'm':
                    return value *= 1000;
                case 'cm':
                    return value *= 100000;
                case 'mm':
                    return value *= 1000000;
                case 'mi':
                    return value *= 0.62137119223733;
                case 'yrd':
                    return value *= 1093.6132983377;
                case 'ft':
                    return value *= 3280.8398950131;
                case 'in':
                    return value *= 39370.078740157;
                default:
                    return value;
            }
        } else if (input === 'm') {
            switch (output) {
                case 'km':
                    return value *= 0.001;
                case 'cm':
                    return value *= 100;
                case 'mm':
                    return value *= 1000;
                case 'mi':
                    return value *= 0.00062137119223733;
                case 'yrd':
                    return value *= 1.0936132983377;
                case 'ft':
                    return value *= 3280.8398950131;
                case 'in':
                    return value *= 39.370078740157;
                default:
                    return value;
            }
        } else if (input === 'cm') {
            switch (output) {
                case 'km':
                    return value *= 0.00001;
                case 'm':
                    return value *= 0.01;
                case 'mm':
                    return value *= 10;
                case 'mi':
                    return value *= 0.0000062137119223733;
                case 'yrd':
                    return value *= 0.010936132983377;
                case 'ft':
                    return value *= 0.032808398950131;
                case 'in':
                    return value *= 0.39370078740157;
                default:
                    return value;
            }
        } else if (input === 'mm') {
            switch (output) {
                case 'km':
                    return value *= 0.000001;
                case 'm':
                    return value *= 0.001;
                case 'cm':
                    return value *= 0.1;
                case 'mi':
                    return value *= 0.00000062137119223733;
                case 'yrd':
                    return value *= 0.001093613298337;
                case 'ft':
                    return value *= 0.0032808398950131;
                case 'in':
                    return value *= 0.039370078740157;
                default:
                    return value;
            }
        } else if (input === 'mi') {
            switch (output) {
                case 'km':
                    return value *= 1.609344;
                case 'm':
                    return value *= 1609.344;
                case 'cm':
                    return value *= 160934.4;
                case 'mm':
                    return value *= 1609344;
                case 'yrd':
                    return value *= 1760;
                case 'ft':
                    return value *= 5280;
                case 'in':
                    return value *= 63360;
                default:
                    return value;
            }
        } else if (input === 'yrd') {
            switch (output) {
                case 'km':
                    return value *= 0.0009144;
                case 'm':
                    return value *= 0.9144;
                case 'cm':
                    return value *= 91.44;
                case 'mm':
                    return value *= 914.4;
                case 'mi':
                    return value *= 0.00056818181818182;
                case 'ft':
                    return value *= 3;
                case 'in':
                    return value *= 36;
                default:
                    return value;
            }
        } else if (input === 'ft') {
            switch (output) {
                case 'km':
                    return value *=  0.0003048;
                case 'm':
                    return value *= 0.3048;
                case 'cm':
                    return value *= 30.48;
                case 'mm':
                    return value *= 304.8;
                case 'mi':
                    return value *= 0.00018939393939394;
                case 'yrd':
                    return value *= 0.33333333333333;
                case 'in':
                    return value *= 12;
                default:
                    return value;
            }
        } else if (input === 'in') {
            switch (output) {
                case 'km':
                    return value *=  0.0000254;
                case 'm':
                    return value *=  0.0254;
                case 'cm':
                    return value *= 2.54;
                case 'mm':
                    return value *= 25.4;
                case 'mi':
                    return value *= 0.000015782828282828;
                case 'yrd':
                    return value *= 0.027777777777778;
                case 'ft':
                    return value *= 0.083333333333333;
                default:
                    return value;
            }
        }
    }
}
