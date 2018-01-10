function Names() {
    var students = [
        { first_name: 'Michael', last_name: 'Jordan' }, //Michael Jordan
        { first_name: 'John', last_name: 'Rosales' }, //John Rosales
        { first_name: 'Mark', last_name: 'Guillen' },
        { first_name: 'KB', last_name: 'Tonel' }
    ]
    for (var i = 0; i < student.length; i++) {
        var student = student[i];
        var output = "";
        console.log(student);
        for (var key in student) {
            output += student[key] + " ";
            console.log(output);
        }
    }
}