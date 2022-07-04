const instructor = [
    {
        instructorName: 'Mr. Instructor CAS',
        isPWD: false,
        college: 'CAS',
        subjects: [
            {
                subject: 'CAS Subject 1',
                category: 'LAB',
            },
            {
                subject: 'CAS Subject 2',
                category: 'LAB',
            },
            {
                subject: 'CAS Subject 3',
                category: 'LAB',
            },
        ],
    },
    {
        instructorName: 'Mr. Instructor CEIS',
        isPWD: false,
        college: 'CEIS',
        subjects: [
            {
                subject: 'CEIS Subject 1',
                category: 'LAB',
            },
            {
                subject: 'CEIS Subject 2',
                category: 'LEC',
            },
            {
                subject: 'CEIS Subject 3',
                category: 'LEC',
            },
        ],
    },
    {
        instructorName: 'Mr. Instructor CTE',
        isPWD: false,
        college: 'CTE',
        subjects: [
            {
                subject: 'CTE Subject 1',
                category: 'LEC',
            },
            {
                subject: 'CTE Subject 2',
                category: 'LEC',
            },
            {
                subject: 'CTE Subject 3',
                category: 'LEC',
            },
        ],
    },
];

const rooms = [
    {
        roomId: 1,
        college: 'CAS',
        roomCategory: 'LAB',
        room: 'Laboratory room',
    },
    {
        roomId: 2,
        college: 'CTE',
        roomCategory: 'LAB',
        room: 'Laboratory room one',
    },
    {
        roomId: 3,
        college: 'CEIS',
        roomCategory: 'LAB',
        room: 'Laboratory room two',
    },
];

const days = [
    {
        id: 1,
        day: 'M',
        description: 'Monday',
    },
    {
        id: 2,
        day: 'T',
        description: 'Tuesday',
    },
    {
        id: 3,
        day: 'W',
        description: 'Wednesday',
    },
    {
        id: 4,
        day: 'TH',
        description: 'Thursday',
    },
    {
        id: 5,
        day: 'F',
        description: 'Friday',
    },
];

const time = [
    {
        id: 1,
        time: '8:00AM - 12:00NN',
    },
    {
        id: 2,
        time: '1:00PM - 5:00PM',
    },
];

const hasLab = () => {
    const a = instructor.filter((x) => {
        for (let i = 0; i < x.subjects.length; i++) {
            if (x.subjects[i].category == 'LAB') return true;
        }
        return false;
    });
    return a;
};

const schedRoom = () => {
    let initialData = [];
    const a = hasLab();
    for (let r = 0; r < rooms.length; r++) {
        for (let i = 0; i < a.length; i++) {
            if (rooms[r].college == a[i].college) {
                initialData.push({ ...a[i] });
            }
        }
    }

    for (let s = 0; s < initialData.length; s++) {
        for (let r = 0; r < rooms.length; r++) {
            if (rooms[r].college == initialData[s].college) {
                for (let l = 0; l < initialData[s].subjects.length; l++) {
                    if (initialData[s].subjects[l].category == 'LAB') {
                        initialData[s].subjects[l].room = rooms[r];
                    }
                }
            }
        }
    }
    return initialData;
};

const schedTime = () => {
    const a = schedRoom();
    for (let i = 0; i < a.length; i++) {
        for (let y = 0; y < a[i].subjects.length; y++)
            for (let t = 0; t < time.length; t++) {
                if (a[i].subjects[y].category == 'LAB') {
                    if (y == 0) {
                        a[i].subjects[y].time = time[t - 1];
                    } else {
                        a[i].subjects[y].time = time[t];
                    }
                }
            }
    }

    return a;
};

const schedDays = () => {
    const a = schedTime();
    for (let t = 0; t < days.length; t++) {
        for (let i = 0; i < a.length; i++) {
            for (let y = 0; y < a[i].subjects.length; y++)
                if (a[i].subjects[y].category == 'LAB') {
                    if(y == 2) {
                        a[i].subjects[y].days = days[1].day;
                    }
                    else {
                        a[i].subjects[y].days = days[0].day;
                    }
                    
                }
        }
    }
    return a;
};

const json = () => JSON.stringify(schedDays());

console.log(json());
