class Organization {
    constructor(name, budget) {
        this.name = name;
        this.employees = [];
        this.budget = budget;

        this.departments = {
            marketing: this.budget * 0.4,
            finance: this.budget * 0.25,
            production: this.budget * 0.35,
        };
    }

    get departmentsBudget() {
        return this.departments;
    }


    add(employeeName, department, salary) {

        if (this.departmentsBudget[department] < salary) {
            return `The salary that ${department} department can offer to you Mr./Mrs. ${employeeName} is $${this.departmentsBudget[department]}.`;
        }

        let employee = {
            employeeName: employeeName,
            department: department,
            salary: salary
        };

        this.employees.push(employee);
        this.departmentsBudget[department] -= salary;
        return `Welcome to the ${employee.department} team Mr./Mrs. ${employee.employeeName}.`;
    }

    employeeExists(employeeName) {

        let findEmployee = this.employees.find(x => x.employeeName === employeeName);

        if (!findEmployee)
            return `Mr./Mrs. ${employeeName} is not working in ${this.name}.`;

        return `Mr./Mrs. ${employeeName} is part of the ${findEmployee.department} department.`;
    }

    leaveOrganization(employeeName) {
        let findEmployee = this.employees.find(x => x.employeeName === employeeName);

        if (!findEmployee)
            return `Mr./Mrs. ${employeeName} is not working in ${this.name}.`;


        let getSalary = findEmployee.salary;
        this.departmentsBudget[findEmployee.department] += getSalary;
        this.employees = this.employees.filter(e => e !== findEmployee);
        return `It was pleasure for ${this.name} to work with Mr./Mrs. ${employeeName}.`
    }

    status() {

        let status = '';

        status += `${this.name.toUpperCase()} DEPARTMENTS:`;
        status += '\n' + this.extractInfo('Marketing');
        status += '\n' + this.extractInfo('Finance');
        status += '\n' + this.extractInfo('Production');

        return status;
    }

    extractInfo(deprt) {
        let department = this.employees.filter(x => x.department === deprt.toLowerCase());
        department.sort((a, b) => b.salary - a.salary);
        let namesOfDepartment = [];
        for (let key of department) {
            namesOfDepartment.push(key.employeeName)
        }
        let salary = this.departmentsBudget[deprt.toLowerCase()];
        //return  `${deprt} | Employees: ${namesOfDepartment.length}: ${namesOfDepartment.join(', ')} | Remaining Budget: ${salary}`;
        return  `${deprt} | Employees: ${department.length}: ${namesOfDepartment.join(', ')} | Remaining Budget: ${salary}`;
    }
}
