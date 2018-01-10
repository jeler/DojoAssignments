function daysToBirthday(days) 
{
    while (days > 30) 
    {
        console.log("I'm sad");
        days--;
        console.log("Only" + " " + days + " " + "left");
    }
    while (days <= 30 && days > 5) 
    {
        console.log("Getting there!");
        days--;
        console.log("Only" + " " + days + "left")
    }
    while (days <= 5 && days > 0) 
    {
        console.log("SO CLOSE");
        days--;
        console.log("Only" + " " + days + " " + "left")
    }
    while (days === 0)
    {
        console.log("♪ღ♪░H░A░P░P░Y░ B░I░R░T░H░D░A░Y░░♪ღ♪");
        days--;
    }
}
daysToBirthday(60);