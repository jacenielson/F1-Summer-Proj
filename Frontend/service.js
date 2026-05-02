export async function GetData() {
    const url = "https://api.openf1.org/v1/";
    const response = await fetch(url);
    const data = response.json();
    return data
}