class Computer {
    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory = ramMemory;
        this.cpuGHz = cpuGHz;
        this.hddMemory = hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];
        this.totalRamUsage = 0;
        this.totalCpuUsage = 0;
    }

    installAProgram(name, requiredSpace) {
        if (this.hddMemory - requiredSpace <= 0) {
            throw  new Error('There is not enough space on the hard drive');
        }
        let obj = {
            name,
            requiredSpace
        };
        this.installedPrograms.push(obj);
        this.hddMemory -= requiredSpace;

        return obj;
    }

    openAProgram(name) {
        let program = this.installedPrograms.find(x => x.name === name);
        if (!program) {
            throw  new Error(`The ${name} is not recognized`);
        }

        let taskFind = this.taskManager.find(x => x.name === name);
        if (taskFind) {
            throw  new Error(`The ${name} is already open`);
        }

        let ram = (program.requiredSpace / this.ramMemory) * 1.5;
        let cpu = ((program.requiredSpace / this.cpuGHz) / 500) * 1.5;

        let obj = {
            name: name,
            ramUsage: ram,
            cpuUsage: cpu,
        };


        let programRAM = program.requiredSpace / this.ramMemory * 1.5;
        this.totalRamUsage += programRAM;

        let programCPU = ((program.requiredSpace / this.cpuGHz ) / 500) * 1.5;
        this.totalCpuUsage += programCPU;

        if (this.totalRamUsage >= 100) {
            throw new Error (`${name} caused out of memory exception`);
        }

        if (this.totalCpuUsage >= 100) {
            throw new Error (`${name} caused out of cpu exception`);
        }

        this.taskManager.push(obj);
        return obj;
    }

    uninstallAProgram(name) {
        let program = this.installedPrograms.find(x => x.name === name);
        if (!program) {
            throw  new Error(`Control panel is not responding`);
        }

        this.hddMemory += program.requiredSpace;
        let index = this.installedPrograms.indexOf(program);
        this.installedPrograms.splice(index, 1);
        return this.installedPrograms;
    }

    taskManagerView() {
        if (this.taskManager.length === 0) {
            return 'All running smooth so far';
        }
        let results = [];
        for (let program of this.taskManager) {
            results.push(`Name - ${program.name} | Usage - CPU: ${program.cpuUsage.toFixed(0)}%, RAM: ${program.ramUsage.toFixed(0)}%`)
        }
        return results.join('\n');
    }
}

