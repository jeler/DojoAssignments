function daysTillBirthday(days) {
    while(days > 0) {
        if(days > 30) {
            console.log("So" + "Sad");
            console.log(days + " " + until + " " + my + " " birthday + "So sad");
            days--;
        }
        if(days < 30 && days > 5) {
            console.log ("Getting there");
            console.log(days + " " + until + " " + my + " " birthday");
            days--;
        }
        if(days >= 5) {
            console.log("SO CLOSE");
            onsole.log(days + " " + until + " " + my + " " birthday");
            days--;
        }
        if (days ===0) {
            console.log("HAPPY BIRTHDAY!!!")
        }
    }
}
daysTillBirthday(20);