
async function GetData(): Promise<number> {
    const response = await fetch("https://jsonplaceholder.typicode.com/todos/1");
    return 10;
}



function initPage(pageId: string) {
    const res = GetData();
    return "FINISHED";
}

function initAll() {
    initPage("page1");
    initPage("page2");

}
