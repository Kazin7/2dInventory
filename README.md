# uGUI Scroll View + GridLayoutGroup 인벤토리

스크롤 가능한 그리드에 슬롯 동적 생성, 아이템 아이콘 표시, 클릭 시 장착/해제, 장착 시 빨간 테두리(Outline) 표시까지 포함한 인벤토리 UI 템플릿입니다.

- Unity 2021.3+ / uGUI 기반

## ✨주요 기능
- 세로 스크롤 인벤토리 그리드
- 프리팹을 이용한 슬롯 동적 생성
- 아이템 데이터 모델: 무기 / 아머(복수 장착) / 액세서리 / 소모품
- 슬롯 클릭으로 장착/해제 토글
- 장착 슬롯 빨간 테두리(Outline) 표시

## 🧩기술 스택
- Unity 2021.3+
- uGUI: ScrollRect, GridLayoutGroup, Image, Button, Outline
- C# 직렬화, List 컬렉션
- 
## 🧱씬 & 프리팹 세팅
### 1) UIInventory 패널
- Canvas 하위에 패널 생성 → 자식으로 Scroll View 추가
- ScrollRect: Vertical On, Horizontal Off
- Viewport: RectMask2D 유지
- Content: GridLayoutGroup 추가 (Constraint: Fixed Column Count, Cell Size/Spacing/Padding 조정)

### 2) ItemSlot 프리팹
- 루트: 배경 Image(SlotImg)
- 자식: Item(버튼 + 아이콘 이미지)
- UISlot 컴포넌트 인스펙터 연결
  - Icon → 자식 Item의 Image
  - Button → 자식 Item의 Button
  - Border Target → SlotImg(Image)
- Outline로 빨간 테두리 표시(예: #FF3B30), 시작 시 비활성화

### 3) UIInventory 인스펙터
- slotPrefab → ItemSlot 프리팹
- slotParent → Scroll View / Viewport / Content
- initialCount → 시작 슬롯 수(예: 12)

## 🔗동작 흐름
1) 초기화: UIInventory가 슬롯 동적 생성, GameManager/Character가 보유 목록 채움  
2) 표시: 인벤토리를 읽어 아이콘 배치, 장착 아이템은 빨간 테두리 표시  
3) 상호작용: 슬롯 클릭 시 장착/해제 토글(아머는 복수 장착)

## 🧠로직 개요
- Item: 식별자, 아이콘, 타입, 개수, 보너스(공/방/체력). 장착 가능 타입=무기/아머/액세서리
- Character: 인벤토리 보유, 무기 1 / 아머 N / 액세서리 1, 장착/해제 시 보너스 가감, 장착 여부 조회
- UISlot: 아이콘 표시/숨김, 버튼 상호작용, 장착 시 BorderTarget Outline 활성화(초기 비활성)
- UIInventory: 프리팹 동적 생성, 데이터 동기화, 클릭 처리 후 갱신

## ✅인스펙터 체크리스트
- UIInventory.slotPrefab = ItemSlot.prefab
- UIInventory.slotParent = Scroll View/Viewport/Content
- UISlot.Icon = Item 이미지, UISlot.Button = Item 버튼
- UISlot.BorderTarget = SlotImg(Image)
- Outline 색상/두께 설정, 시작 시 비활성
- GridLayoutGroup(Cell Size/Spacing/Constraint) 확인
- ScrollRect Vertical On / Horizontal Off

## ❓트러블슈팅
- 아이콘 미표시: UISlot.Icon 연결, 스프라이트 Import 설정 확인
- 클릭 안 됨: Button 연결, Canvas Graphic Raycaster / EventSystem 확인
- 테두리 미표시: Outline 존재/색상, BorderTarget가 SlotImg인지 확인
- 그리드 찌그러짐: Content RectTransform 앵커/피벗, Cell Size/Constraint 점검
