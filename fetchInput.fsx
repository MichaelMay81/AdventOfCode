open System
open System.IO
open System.Net
open System.Net.Http

let fetchWebsiteContent (httpClient:HttpClient) (url: string) =
    async {
        let! response = httpClient.GetAsync(url) |> Async.AwaitTask
        let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
        return content
    }

let fetchAocInput (year:int) (day:int) (sessionCookie:string) =
    let aocUrl = "https://adventofcode.com"

    use handler = new HttpClientHandler()
    handler.CookieContainer.Add(new Uri(aocUrl), Cookie("session", sessionCookie))
    use httpClient = new HttpClient(handler)

    fetchWebsiteContent httpClient $"{aocUrl}/{year}/day/{day}/input"
    |> Async.RunSynchronously

let usage = """Usage: dotnet fsi fetchInput.fsx [year] [day] [sessionCoockie]
Downloads AoC input and saves it into 'AoC-[year]/inputs/day[day].txt'"""

match Environment.GetCommandLineArgs() with
| [| _; _; year; day; sessionCookie |] ->
    match year |> Int32.TryParse, day |> Int32.TryParse with
    | (true, year), (true, day) ->
        use writer = new StreamWriter($"AoC-{year}/inputs/Day{day}.txt")
        fetchAocInput year day sessionCookie
        |> writer.Write

    | _ -> printfn "%s" usage 
| _s ->
    printfn "%s" usage