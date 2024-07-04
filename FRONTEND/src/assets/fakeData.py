import requests

fake_data = [
    "Khuê Cao",
    "Thành Trọng",
    "Ý Cao",
    "Huyền Yến",
    "Nhung Thiên",
    "Nhi Như",
    "Xuân Hạo",
    "Mai Đan",
    "Anh Bảo",
    "Hân Vân",
]

for data in fake_data:
    username = (
        data.lower()
        .replace(" ", "-")
        .replace("à", "a")
        .replace("á", "a")
        .replace("ạ", "a")
        .replace("ả", "a")
        .replace("ã", "a")
        .replace("â", "a")
        .replace("ầ", "a")
        .replace("ấ", "a")
        .replace("ậ", "a")
        .replace("ẩ", "a")
        .replace("ẫ", "a")
        .replace("ă", "a")
        .replace("ằ", "a")
        .replace("ắ", "a")
        .replace("ặ", "a")
        .replace("ẳ", "a")
        .replace("ẵ", "a")
        .replace("è", "e")
        .replace("é", "e")
        .replace("ẹ", "e")
        .replace("ẻ", "e")
        .replace("ẽ", "e")
        .replace("ê", "e")
        .replace("ề", "e")
        .replace("ế", "e")
        .replace("ệ", "e")
        .replace("ể", "e")
        .replace("ễ", "e")
        .replace("ì", "i")
        .replace("í", "i")
        .replace("ị", "i")
        .replace("ỉ", "i")
        .replace("ĩ", "i")
        .replace("ò", "o")
        .replace("ó", "o")
        .replace("ọ", "o")
        .replace("ỏ", "o")
        .replace("õ", "o")
        .replace("ô", "o")
        .replace("ồ", "o")
        .replace("ố", "o")
        .replace("ộ", "o")
        .replace("ổ", "o")
        .replace("ỗ", "o")
        .replace("ơ", "o")
        .replace("ờ", "o")
        .replace("ớ", "o")
        .replace("ợ", "o")
        .replace("ở", "o")
        .replace("ỡ", "o")
        .replace("ù", "u")
        .replace("ú", "u")
        .replace("ụ", "u")
        .replace("ủ", "u")
        .replace("ũ", "u")
        .replace("ư", "u")
        .replace("ừ", "u")
        .replace("ứ", "u")
        .replace("ự", "u")
        .replace("ử", "u")
        .replace("ữ", "u")
        .replace("ỳ", "y")
        .replace("ý", "y")
        .replace("ỵ", "y")
        .replace("ỷ", "y")
        .replace("ỹ", "y")
    )
    nameInPassword = username.capitalize()
    password = "@" + nameInPassword + "12345"
    response = requests.post(
        "https://localhost:7029/api/Authentication/Register",
        json={
            "fullName": data,
            "userName": username,
            "email": f"{username}@gmail.com",
            "password": password,
        },
        verify=False,
    )
