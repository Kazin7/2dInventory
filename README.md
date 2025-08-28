# uGUI Scroll View + GridLayoutGroup 인벤토리

스크롤 가능한 그리드에 슬롯 동적 생성, 아이템 아이콘 표시, 클릭 시 장착/해제, 장착 시 E 표시까지 포함한 인벤토리 UI 템플릿입니다.

- Unity 2022.3.17f / uGUI 기반

## ✨주요 기능
- 세로 스크롤 인벤토리 그리드
- 프리팹을 이용한 슬롯 동적 생성
- 아이템 데이터 모델: 무기 / 아머(복수 장착) / 액세서리
- 슬롯 클릭으로 장착/해제 토글
- 장착 슬롯 E 아이콘 표시

## 🧩기술 스택
- Unity 2022.3.17f
- uGUI: ScrollRect, GridLayoutGroup, Image, Button, Outline(변경)
- C# 직렬화, List 컬렉션
- 
## 🧱씬 & 프리팹 세팅
### 1) UIMainMenu 패널
-플레이어의 이름, 레벨과 경험치 화면에 표시
-UIStatus,UIInventory를 활성화하는 방식 사용
### 2) UIStatus 패널
-공격력,방어력,체력 표시(아이템 적용시 그 수치도 추가하여 표시)
### 3) UIInventory 패널
-12개의 슬롯으로 시작(ItemSlot 12개를 Instantiate)
-아이템에 마우스 hover시 UITooltip패널 등장(IPointerEnterHandler, IPointerExitHandler사용)
### 3) UITooltip 패널(프리팹화하여 아이템 hover시 Instantiate하는 방식)
-Show함수에서 아이템 정보를 출력하도록 텍스트 설정
### 2) ItemSlot 프리팹
- 루트: 배경 Image(SlotImg)
- 자식: Item(버튼 + 아이콘 이미지)
- UISlot 컴포넌트 인스펙터 연결
  - Icon → 자식 Item의 Image
  - Button → 자식 Item의 Button
  - Border Target → SlotImg(Image)
- 장착시 E 표시

## 🔗동작 흐름
1) 초기화: UIInventory가 슬롯 동적 생성, GameManager/Character가 보유 목록 채움  
2) 표시: 인벤토리를 읽어 아이콘 배치, 장착 아이템은 E 표시  
3) 상호작용: 슬롯 클릭 시 장착/해제 토글(아머는 복수 장착)

## 🧠로직 개요
- Item: 식별자, 아이콘, 타입, 개수, 보너스(공/방/체력). 장착 가능 타입=무기/아머/액세서리
- Character: 인벤토리 보유, 무기 1 / 아머 N / 액세서리 1, 장착/해제 시 보너스 가감, 장착 여부 조회
- UISlot: 아이콘 표시/숨김, 버튼 상호작용, 장착 시 BorderTarget Outline 활성화(초기 비활성)
- UIInventory: 프리팹 동적 생성, 데이터 동기화, 클릭 처리 후 갱신

## ✨메인 화면
<img width="993" height="483" alt="image" src="https://github.com/user-attachments/assets/edd6c652-ca16-4e6a-a76d-df6ca23b3e65" />

## ✨스테이터스 화면
<img width="983" height="538" alt="image" src="https://github.com/user-attachments/assets/82a77005-da31-4095-919d-4eb2c0ced008" />

## ✨인벤토리 화면 아이템 장착과 정보 표시
<img width="987" height="539" alt="image" src="https://github.com/user-attachments/assets/bc483169-1cc3-4142-aa74-b79ebf9783e3" />
