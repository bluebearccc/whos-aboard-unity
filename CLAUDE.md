# WHO'S ABOARD? — bản Unity

Viết lại game web `../tram-khong-gian` (TypeScript) bằng C# trong Unity **6000.3.29f1** (LTS).
Kế hoạch + trạng thái từng phần: `../tram-khong-gian/Unity-Migration.md` (cập nhật file đó sau mỗi phần).
Luật chơi, nội dung bài/nhân vật/vùng: đọc `../tram-khong-gian/CLAUDE.md` và `../tram-khong-gian/src/`.

- `Assets/Scripts/Engine/` — engine C# thuần (asmdef `noEngineReferences`), port 1-1 từ `src/engine/` + `src/data/`. Phải ra đúng kết quả như bản TS (cùng seed -> cùng ván).
- `Assets/Tests/EditMode/` — test NUnit. Chạy (không cần mở Editor, đóng Editor trước):
  `"/c/Program Files/Unity/Hub/Editor/6000.3.29f1/Editor/Unity.exe" -batchmode -projectPath . -runTests -testPlatform EditMode -testResults TestResults.xml -logFile -`
- Online: client Unity nối vào server Node của bản web (`wss://tram-khong-gian.onrender.com/ws`), cùng giao thức JSON.
- Người dùng mới học lập trình → giải thích bằng tiếng Việt, đơn giản.

<!-- haren:begin -->
## Haren Framework

This workspace uses the Haren agentic SDLC framework.

**On every session start, you MUST:**
1. Read `haren/skill.md` — this is your operating manual
2. Follow its instructions for session orientation
3. Read `haren/manifest.yaml` and `haren/progress.json` before taking any action

All project documentation, specs, plans, and artifacts are managed inside `haren/`.
Write outside `haren/` only in the module's repos (see "Repos and Git" in `haren/skill.md`), only from the `planned` status on (implement phase) or when qa-engineer writes tests in `$E2E`. For a change the user explicitly asks for, use the gate override (see below).

## Brainstorming Gate

Before writing ANY code outside `haren/`:
1. Read `haren/progress.json` and `haren/manifest.yaml`
2. Write code only inside the repos of a module with status `planned`, `implementing`, `evaluating`, `completed`, or `released` (the module's `repos` keys in progress.json)
3. `discovered` and `decomposed` do NOT allow code. If no module is at `planned` or later, STOP and tell the user to run the plan phase.
4. Exception: the user explicitly asks for a change (for example a hotfix). Run `haren track override on --reason "<what the user asked>"`, make the change, then run `haren track override off`.

Design specs are written to Haren artifact folders, NOT to docs/superpowers/specs/.
<!-- haren:end -->
