# WHO'S ABOARD? — bản Unity

Board game **vai trò ẩn** cho 4–8 người, lấy bối cảnh một trạm không gian bỏ hoang. Mỗi người nhận bí mật một nhân vật thuộc 1 trong 3 phe:

- **Phi Hành Gia** — thắng khi mọi Ký Sinh đã chết.
- **Ký Sinh** — thắng khi mọi Phi Hành Gia đã chết, hoặc 3 Trung Lập đã chết.
- **Trung Lập** — mỗi nhân vật có điều kiện thắng riêng.

Mỗi lượt: tung d6 + d4 để di chuyển giữa 6 khu vực của trạm, dùng hiệu ứng khu vực, rút bài từ 3 bộ (**Tín Hiệu**, **Tiếp Tế**, **Sự Cố**), rồi tấn công người cùng tầm. Không ai biết ai thuộc phe nào cho tới khi lật bài.

Repo này viết lại toàn bộ game bằng **C# trong Unity**, từ bản web gốc (TypeScript) đang chạy tại https://tram-khong-gian.onrender.com.

## Trạng thái

🚧 **Mới bắt đầu.** Đã có project trống và bộ sinh số ngẫu nhiên, chưa chơi được.

| Phần | Nội dung | Trạng thái |
|------|----------|-----------|
| U0 | Tạo project, chạy test bằng dòng lệnh | ✅ |
| U1 | Luật chơi + bot bằng C#, so khớp với bản web | ⬜ |
| U2 | Giao diện chơi offline với bot | ⬜ |
| U3 | Hiệu ứng, âm thanh, đoạn mở đầu, hướng dẫn | ⬜ |
| U4 | Chơi online (chung phòng với người chơi bản web) | ⬜ |
| U5 | Build Windows / Android | ⬜ |

## Yêu cầu

- **Unity 6000.3.29f1** (Unity 6.3 LTS), cài qua [Unity Hub](https://unity.com/download).
- Tài khoản Unity (license Personal miễn phí).

## Mở project

1. Mở **Unity Hub** → **Projects** → **Add** → chọn thư mục repo này.
2. Lần đầu mở sẽ lâu (Unity tạo thư mục `Library/`).

## Chạy test

Đóng Unity Editor trước, rồi chạy trong Git Bash ở thư mục repo:

```bash
"/c/Program Files/Unity/Hub/Editor/6000.3.29f1/Editor/Unity.exe" -batchmode -projectPath . \
  -runTests -testPlatform EditMode -testResults TestResults.xml -logFile -
```

Kết quả nằm trong `TestResults.xml` (`result="Passed"` là đạt). Hoặc trong Editor: **Window → General → Test Runner → EditMode → Run All**.

## Cấu trúc

```
Assets/
├── Scripts/Engine/     Luật chơi C# thuần (không dùng UnityEngine)
│                       → dùng lại được cho server sau này
└── Tests/EditMode/     Test NUnit cho engine
Packages/               Danh sách gói Unity
ProjectSettings/        Cài đặt project
```

## Nguyên tắc

- **Cùng seed → cùng ván** như bản web. Engine C# phải cho kết quả giống hệt bản TypeScript, có test so khớp.
- **Online dùng chung server** với bản web (WebSocket, cùng giao thức JSON) → người chơi Unity và web vào chung phòng được. Server giữ mọi bí mật (nhân vật chưa lật, thứ tự bài), máy người chơi chỉ nhận phần được phép thấy.
- Nhân vật, khu vực, lá bài, hình ảnh đều **tự thiết kế**; chỉ lấy cảm hứng *cơ chế* từ thể loại board game vai trò ẩn.
