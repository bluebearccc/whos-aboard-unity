# WHO'S ABOARD? — bản Unity

Viết lại game web `../tram-khong-gian` (TypeScript) bằng C# trong Unity **6000.3.29f1** (LTS).
Kế hoạch + trạng thái từng phần: `../tram-khong-gian/Unity-Migration.md` (cập nhật file đó sau mỗi phần).
Luật chơi, nội dung bài/nhân vật/vùng: đọc `../tram-khong-gian/CLAUDE.md` và `../tram-khong-gian/src/`.

- `Assets/Scripts/Engine/` — engine C# thuần (asmdef `noEngineReferences`), port 1-1 từ `src/engine/` + `src/data/`. Phải ra đúng kết quả như bản TS (cùng seed -> cùng ván).
- `Assets/Tests/EditMode/` — test NUnit. Chạy (không cần mở Editor, đóng Editor trước):
  `"/c/Program Files/Unity/Hub/Editor/6000.3.29f1/Editor/Unity.exe" -batchmode -projectPath . -runTests -testPlatform EditMode -testResults TestResults.xml -logFile -`
- Online: client Unity nối vào server Node của bản web (`wss://tram-khong-gian.onrender.com/ws`), cùng giao thức JSON.
- Người dùng mới học lập trình → giải thích bằng tiếng Việt, đơn giản.
