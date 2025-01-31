import DatabaseTaskModel from "../models/databaseTask";

export default isTaskDueAt;

function isTaskDueAt(task: DatabaseTaskModel, date: Date){
    if(task.done_at === null)
    {
        return true;
    }

    let due_time = new Date("1970-01-01T" + task.to_be_done_at)

    var dueToday = new Date(date.getFullYear(), date.getMonth(), date.getDate(),
        due_time.getHours(), due_time.getMinutes());

    let doneAt = new Date(task.done_at);

    if(date < dueToday)
    {
        dueToday.setTime(dueToday.getTime() - 24*3600*1000)
    }

    if(dueToday.valueOf() < doneAt.valueOf())
    {
        return false;
    }else{
        return true;
    }
}