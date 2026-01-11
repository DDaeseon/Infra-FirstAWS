// EN: Create a builder that prepares app configuration, logging, and DI container.
// KO: 앱 설정(Configuration), 로깅(Logging), DI 컨테이너 등을 준비하는 "빌더"를 만든다.
var builder = WebApplication.CreateBuilder(args);

// EN: Build the actual web app instance (this will become the HTTP server).
// KO: 실제로 실행될 웹 애플리케이션(HTTP 서버 본체)을 만든다.
var app = builder.Build();

// EN: Route mapping (Routing).
// EN: Map GET requests to "/" (root path) to this handler.
// EN: Returning a string automatically becomes "200 OK" with text/plain.
// KO: 라우팅 등록.
// KO: GET "/" 요청이 오면 이 핸들러가 실행된다.
// KO: string을 반환하면 ASP.NET Core가 자동으로 "200 OK" + text/plain 응답을 만들어 준다.
app.MapGet("/", () => "Hello World!");

// EN: Health check endpoint used by load balancers/monitors (e.g., AWS ALB health checks).
// EN: Results.Ok(...) explicitly returns HTTP 200.
// EN: The anonymous object is automatically serialized to JSON in the response body.
// KO: 헬스체크 엔드포인트(로드밸런서/모니터링이 호출. 예: AWS ALB 헬스체크).
// KO: Results.Ok(...)는 HTTP 200 응답을 "명시적으로" 만든다.
// KO: 익명 객체(new { ... })는 자동으로 JSON으로 직렬화되어 응답 바디로 내려간다.
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

// EN: Start the server (Kestrel). It begins listening on a port (shown in the console).
// EN: The process keeps running until you stop it (Ctrl+C).
// KO: 서버(Kestrel)를 시작한다. 포트를 열고 요청을 기다린다(콘솔에 포트가 출력됨).
// KO: Ctrl+C로 종료할 때까지 계속 실행되며 요청을 처리한다.
app.Run();
