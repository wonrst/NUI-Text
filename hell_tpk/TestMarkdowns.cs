using System;
using System.Collections.Generic;

namespace NUIText
{
    internal static class TestMarkdowns
    {
        private static int currentIndex = 0;
        private static readonly Random rand = new Random();

        public static int Count => samples.Count;

        public static string GetSample(int index)
        {
            if (samples.Count == 0) return string.Empty;
            index = ((index % samples.Count) + samples.Count) % samples.Count;
            return samples[index];
        }

        public static string GetRandom()
        {
            if (samples.Count == 0) return string.Empty;
            return samples[rand.Next(samples.Count)];
        }

        public static string GetNext()
        {
            if (samples.Count == 0) return string.Empty;
            currentIndex = (currentIndex + 1) % samples.Count;
            return samples[currentIndex];
        }

        public static string GetPrev()
        {
            if (samples.Count == 0) return string.Empty;
            currentIndex = (currentIndex - 1 + samples.Count) % samples.Count;
            return samples[currentIndex];
        }

        private static readonly List<string> samples = new List<string>
        {
@"## 🇰🇷 손흥민 (Son Heung-min)

> ""아시아의 자존심, 프리미어리그의 레전드""

---

### 🧾 기본 정보
- **출생**: 1992년 7월 8일, 강원도 춘천  
- **신체**: 183cm / 77kg  
- **포지션**: 공격수 (윙어, 스트라이커)  
- **소속팀**: 토트넘 홋스퍼 FC (등번호 7)  
- **국가대표**: *대한민국* 축구 대표팀   

---

### 🏅 주요 커리어 요약

| 구분           | 주요 기록 및 성과                                                 |
|----------------|------------------------------------------------------------------|
| 프리미어리그   | 100+ 골 기록 (아시아 선수 최초)                                  |
| 득점왕         | 2021–22 시즌 득점왕 (23골, 살라와 공동)                          |
| 챔피언스리그   | 2019 결승전 선발 출전 (vs 리버풀)                                |
| 국가대표       | A매치 130+경기 / 50+골                                            |
| 국제대회       | 2018 아시안게임 금메달, 2014·2018·2022 월드컵 참가                |
| 개인 수상      | 2020 FIFA 푸슈카시상 (번리전 단독 드리블 골)                      |

---

### 💡 특징 및 성장 배경

- 양발잡이 / 스피드와 슈팅력 뛰어남  
- 철저한 기본기 훈련 (아버지 손웅정 지도)  
- 겸손하고 성실한 태도로 팬과 동료에게 존경받음  

---

### 🎯 대표 명언

> “겸손하라. 감사하라. 그러면 너의 것이 된다.”  
> – 손웅정 (손흥민 아버지)

---

## ✅ 요약 한줄

> **손흥민은 ~~아시아~~ 축구의 한계를 넘어선 세계적인 공격수입니다.**
"
,

@"# How to Optimize Your Workflow in 2025
 
In today's fast-paced world, it's *critical* to optimize your **daily workflow**. Here's a quick summary of what we'll cover:
 
1. Time management techniques
2. Tools that actually help
3. Common mistakes to avoid
 
> ""The key is not to prioritize what's on your schedule, but to schedule your priorities."" 
> — Stephen Covey
 
## 🔧 Recommended Tools
 
Here are some tools we found helpful:
 
- [Notion](https://www.notion.so) for knowledge management
- ~~Evernote~~ (deprecated in our tests)
- **Obsidian** for offline markdown note-taking
 
And don't forget inline `code snippets` like `git commit -m ""optimize workflow""`.
 
### ✅ Quick Tips
 
- **Batch** similar tasks together
  - For example, answer all emails in a 30-minute block
- Use `Pomodoro` technique
- Avoid context switching
 
### 🧠 Example Table
 
| Tool      | Purpose              | Free Plan |
|-----------|----------------------|-----------|
| Notion    | All-in-one workspace | ✅        |
| Obsidian  | Markdown editor      | ✅        |
| Trello    | Task management      | ✅        |
 
### 🧪 Sample Code
 
```csharp
public class WorkflowOptimizer
{
    public void Optimize()
    {
        Console.WriteLine(""Workflow optimized!"");
    }
}
```
"
,

@"# What is Self-Supervised Learning?

Self-supervised learning is a branch of machine learning where a model learns to predict part of its input from other parts of the input, **without requiring explicit labels**. This is in contrast to traditional supervised learning, which depends on labeled datasets.

---

## 🔍 Key Characteristics

- **No Manual Labels:** The model generates its own ""labels"" from the data.
- **Pretext Tasks:** Typical pretext tasks include:
  - *Predicting missing words* in a sentence
  - *Colorizing grayscale images*
  - *Predicting the next frame* in a video

---

> ""Self-supervised learning unlocks the ability to learn from vast amounts of unlabeled data.""  
> — Yann LeCun

---

## 🚀 Popular Approaches

| Approach   | Domain        | Example           |
|------------|---------------|------------------|
| Masked LM  | NLP           | BERT             |
| Contrastive| Vision        | SimCLR, MoCo     |
| Autoencoders | General     | Variational AE   |

### Sample Code (PyTorch)

```python
import torch.nn as nn

class AutoEncoder(nn.Module):
    def __init__(self):
        super().__init__()
        self.enc = nn.Linear(784, 64)
        self.dec = nn.Linear(64, 784)
    def forward(self, x):
        z = self.enc(x)
        return self.dec(z)
```

### 📝 Summary

- Self-supervised learning = **labels from data itself**
- Core to large language models (LLMs) and modern AI

For more info, see [LeCun's talk](https://youtu.be/MkN6a6C1b_w).
"
,

@"# 챗봇 개발을 위한 필수 기술 가이드

챗봇은 사용자와 자연스럽게 대화하며 정보를 제공하거나 업무를 자동화하는 소프트웨어입니다.  
최근에는 AI와 LLM(대규모 언어모델)을 활용한 챗봇이 주목받고 있습니다.

---

## 🎯 챗봇 개발 핵심 요소

- **대화 관리**: 사용자의 의도를 파악하고 적절한 답변을 생성
- **자연어 처리(NLP)**: 텍스트 분석, 토큰화, 의도 분류 등
- **외부 연동**: API, 데이터베이스 등 다양한 시스템과의 연동

---

### 🔗 대표 플랫폼 예시

| 플랫폼      | 특징             | 사용 언어     |
|-------------|------------------|--------------|
| Dialogflow  | 구글 기반, 쉬운 연동 | Python, Node.js |
| Kakao i     | 한국어 지원, 카카오톡 연동 | Java, Python   |
| Rasa        | 오픈소스, 커스텀 용이 | Python         |

---

> ""좋은 챗봇은 사용자의 맥락을 이해하고,  
> 반복적인 질문에도 변화를 준다.""  
> — 챗GPT

---

## 💻 간단한 챗봇 코드 (Python)

```python
def chat(message):
    if ""안녕"" in message:
        return ""안녕하세요! 무엇을 도와드릴까요?""
    elif ""날씨"" in message:
        return ""오늘의 날씨는 맑음입니다.""
    else:
        return ""죄송해요. 아직 그 질문에는 답변할 수 없어요.""
```

### ✅ 챗봇 개발 팁

- **정확한 데이터 수집 및 사전 처리**
- **사용자 피드백 반영** → 지속적인 개선
- **LLM 활용 시, 프롬프트 설계 중요**

---

더 많은 정보는  
[카카오 i 오픈빌더 공식 문서](https://i.kakao.com/openbuilder)에서 확인하세요!
"
,

@"
# 🎨 UI/UX 트렌드 2025

최근 UI/UX 분야에서는 **직관성**과 **접근성**이 중요한 화두입니다.

---

## 📌 핵심 트렌드

- **다크 모드**: 눈의 피로를 줄이고, 배터리 효율 개선  
- **마이크로 인터랙션**: 사용자의 작은 행동에 즉각 반응  
- **음성 인터페이스**: 음성 기반 명령 및 피드백 제공

> “좋은 디자인은 설명이 필요 없다.”  
> — Dieter Rams

---

### 🌐 주요 툴 비교

| 툴         | 특징               | 사용 언어  |
|------------|--------------------|------------|
| Figma      | 실시간 협업        | Web        |
| Adobe XD   | 프로토타이핑       | Windows/Mac|
| Sketch     | 맥OS 전용          | Mac        |

---

## 💡 개발자 팁

- **반응형 디자인**을 항상 고려할 것
- 접근성(Accessibility) 체크는 필수
- 사용자 피드백 적극 반영

---

# 📊 데이터 시각화란?

데이터 시각화는 복잡한 정보를 **시각적**으로 표현하여 이해를 돕는 기술입니다.

---

## 주요 그래프 종류

1. **막대그래프**: 항목별 비교  
2. **선그래프**: 시간에 따른 변화  
3. **원그래프(파이차트)**: 비율

---

| 차트 종류 | 용도           | 예시 툴   |
|-----------|----------------|-----------|
| Bar       | 값 비교        | Excel     |
| Line      | 추이 분석      | Tableau   |
| Pie       | 비율           | Power BI  |

",

@"
# 📚 How to Write Clean Code

Writing clean code is essential for maintainability and scalability.

---

## Principles

1. **Meaningful Names**: Use descriptive variable and function names.
2. **Single Responsibility**: Each function should have one purpose.
3. **Comment Wisely**: Comments should explain *why*, not *what*.

---

### Common Mistakes

- Overly long functions  
- Unused variables  
- Poor naming conventions

---

> “Any fool can write code that a computer can understand. Good programmers write code that humans can understand.”  
> — Martin Fowler

---

### Example (JavaScript)

```javascript
// Bad Example
function a(x) {
    return x+1;
}

// Good Example
function increment(value) {
    return value + 1;
}
```

For more, check out Clean Code by Robert C. Martin.

---

# 🚀 Getting Started with REST APIs

A REST API (Representational State Transfer) allows clients to interact with servers via HTTP.

---

## 🔑 Key Concepts

- **Endpoint**: A specific URL where the API can be accessed.
- **Method**: GET, POST, PUT, DELETE
- **Status Code**: 200 (OK), 404 (Not Found), etc.

---

",

@"
# 🌱 환경 보호 실천 가이드

환경 보호는 작은 실천에서 시작됩니다.

---

## 🚲 일상 속 실천법

- 대중교통 이용하기
- 일회용품 줄이기
- 재활용 분리배출

---

> “지구는 우리가 물려받은 것이 아니라,  
> 미래 세대로부터 빌린 것이다.”  
> — 원주민 속담

---

## ♻️ 분리배출 분류표

| 품목       | 처리 방법   |
|------------|------------|
| 페트병     | 뚜껑·라벨 제거 후 압축 |
| 종이류     | 테이프·스테이플러 제거 |
| 플라스틱   | 이물질 제거 후 배출    |

---

### 📋 오늘의 미션

- 집 안 쓰레기 분리배출 실천하기  
- 텀블러 챙겨 다니기

",

@"
# 📺 오늘의 추천 영화

주말에 가족과 함께 볼 만한 최신 인기 영화 TOP 3를 소개합니다.

---

## 🎬 추천 리스트

1. **서울의 봄**
2. **범죄도시 4**
3. **인사이드 아웃 2**

---

| 영화 제목      | 장르      | 상영 시간 | 등급    |
|---------------|-----------|-----------|---------|
| 서울의 봄     | 드라마    | 141분     | 15세 이상 |
| 범죄도시 4    | 액션/코미디 | 109분   | 15세 이상 |
| 인사이드 아웃 2| 애니메이션 | 96분    | 전체 관람가 |

---

> ""좋은 영화는 다시 보고 싶게 만든다.""

---

# 🔍 TV로 할 수 있는 인기 검색어

요즘 사람들이 TV에서 자주 찾는 기능을 알려드릴게요!

---

- 유튜브로 최신 뮤직비디오 보기
- 넷플릭스 인기 드라마 시청
- 날씨/미세먼지 정보 확인
- 스포츠 실시간 중계 보기
- 유아용 콘텐츠 자동 추천

---

| 기능              | 사용 빈도   |
|-------------------|------------|
| 유튜브            | ★★★★★      |
| 넷플릭스          | ★★★★☆      |
| 실시간 뉴스       | ★★★★☆      |
| 음악 스트리밍     | ★★★☆☆      |
| 게임              | ★★☆☆☆      |

---

> “TV는 더 이상 단순한 시청 기기가 아닙니다.  
> 다양한 엔터테인먼트의 허브죠!”

",

@"
# 👀 TV 시청 꿀팁 & 사용자 Q&A

집에서 TV를 더 스마트하게 즐기는 실전 팁과 자주 묻는 질문입니다.

---

## TV 활용 팁

- **음성 명령**: “유튜브 틀어줘”, “채널 11번 켜줘” 등 자연어 명령 지원
- **모바일 미러링**: 휴대폰 화면을 TV로 간편하게 공유
- **시청 기록 기반 추천**: 좋아하는 장르, 출연 배우 기반 자동 추천
- **IoT 연동**: 에어컨, 조명 등 집안 기기와 연동 제어

---

| 기능            | 설명                      | 활용 예시                  |
|-----------------|--------------------------|----------------------------|
| 음성 검색       | 마이크로 직접 질문        | “오늘 날씨 어때?”           |
| 리모컨 앱       | 휴대폰으로 TV 조작        | TV 볼륨/채널 제어           |
| 화면 캡처/저장  | 방송 화면 사진으로 저장   | 요리 프로그램 레시피 저장   |
| 즐겨찾기        | 자주 보는 채널/프로그램 등록 | 뉴스, 드라마, 스포츠        |

---

> “최신 TV는 ‘시청’에서 ‘참여’로 진화하고 있습니다.”

---

### 📢 사용자 Q&A

**Q. TV에 자주 뜨는 알림을 끄는 방법은?**  
A. TV 설정 메뉴의 ‘알림 관리’에서 원치 않는 알림을 개별로 OFF 할 수 있습니다.

**Q. 어린이 시청 제한 기능이 있나요?**  
A. 각 플랫폼별 ‘시청 보호 모드’ 또는 ‘자녀 보호’ 메뉴를 통해 사용 가능합니다.

---

더 많은 활용법은 TV 내 ‘도움말’ 메뉴 또는 음성 검색으로 쉽게 찾아보세요!
",

@"
# 🎬 OTT & TV 신작 안내

이번 주 집에서 즐길 만한 신작과 추천 콘텐츠 총정리!

---

## 🔥 인기 OTT 신작 TOP 5

1. **넷플릭스**: ‘종이의 집: 베를린’ (범죄·스릴러)
2. **티빙**: ‘장미의 전쟁’ (리얼리티 예능)
3. **디즈니+**: ‘로키 시즌2’ (SF·판타지)
4. **웨이브**: ‘약한영웅 Class 1’ (학원 액션)
5. **왓챠**: ‘이번 생도 잘 부탁해’ (로맨스·판타지)

---

| OTT 플랫폼  | 추천 장르      | 대표 신작              | 특징                |
|-------------|---------------|------------------------|---------------------|
| 넷플릭스     | 스릴러/드라마 | 종이의 집: 베를린      | 빠른 전개, 반전 가득 |
| 티빙        | 예능/리얼리티 | 장미의 전쟁            | 현실 부부 이야기    |
| 디즈니+      | 히어로/SF     | 로키 시즌2             | 마블 세계관 확장    |
| 웨이브       | 액션/청춘     | 약한영웅 Class 1       | 실감 나는 액션      |
| 왓챠         | 로맨스/판타지 | 이번 생도 잘 부탁해    | 따뜻한 감성         |

---

> “OTT 신작은 매주 업데이트, 보고 싶은 콘텐츠는 ‘관심작’에 등록해 두세요!”

---

## 📢 활용 팁

- TV 음성검색으로 ‘플랫폼+제목’ 바로 찾아보기  
- 시청내역 기반으로 개인 맞춤 추천 받기  
- 어린이/가족 전용 콘텐츠 구분 기능 활용  
- 스마트폰과 연동해 시청 위치 이어보기

---

더 궁금한 신작 정보는 “이번 주 신작 뭐 있어?”라고 TV에 물어보세요!
",

@"
# ☀️ 오늘의 날씨 & 생활 꿀팁

TV로 간편하게 전국 날씨와 건강 생활 정보를 확인하세요!

---

## 전국 주요 도시 예보

- **서울**: 맑고 무더움, 낮 최고 32℃ / 밤 최저 23℃
- **부산**: 구름 조금, 낮 최고 29℃
- **대전**: 오후 소나기, 우산 챙기세요
- **광주**: 미세먼지 ‘보통’, 야외활동 무리 없음

---

| 지역     | 미세먼지    | 자외선지수 | 강수확률 | 오늘의 팁           |
|----------|-------------|------------|----------|---------------------|
| 서울     | 나쁨        | 높음       | 10%      | 외출 전 선크림 필수 |
| 부산     | 좋음        | 보통       | 20%      | 해변 산책 적기      |
| 대전     | 보통        | 높음       | 60%      | 소나기 대비 필요    |
| 광주     | 좋음        | 낮음       | 30%      | 산책하기 좋은 날씨  |

---

> ""폭염 시엔 충분한 수분 섭취와 휴식이 필수!""

---

## 생활 꿀팁 & Q&A

- 실내는 26~28도, 에어컨은 2시간마다 환기  
- 자외선 강한 오후엔 외출 자제  
- 미세먼지 농도 높을 땐 KF94 마스크 착용 권장

**Q. TV에서 날씨 알림을 미리 받을 수 있나요?**  
A. 최신 스마트TV는 생활정보 위젯에서 실시간 알림 설정이 가능합니다!

---

더 자세한 지역별 기상 정보는 “오늘 날씨 자세히”라고 TV에 말해보세요!
",

@"
# ⚽ 오늘의 스포츠 분석 & 이슈

스포츠 팬을 위한 오늘 경기 결과와 핫이슈, 선수별 스토리까지!

---

## 🏆 주요 경기 결과

- **프로야구**: LG 5:3 두산 (9회말 짜릿한 역전승)
- **K리그**: 전북 2:2 울산 (극적 동점골)
- **NBA**: LA 레이커스 108:105 골든스테이트 (르브론 34득점)

---

| 종목     | 스타플레이어   | 오늘의 한마디                |
|----------|----------------|-----------------------------|
| 야구     | 박병호         | “승부처에서 강한 집중력!”   |
| 축구     | 김민재         | “수비 리더십 빛났다”        |
| 농구     | 르브론 제임스  | “결정적 순간 빅플레이”      |

---

> “경기는 끝나도 이야기는 계속됩니다.”  
> — 스포츠 평론가 신동민

---

## 🔍 오늘의 이슈 포인트

- **프로야구 플레이오프 향방**
  - 남은 경기 일정과 각 팀별 전력 분석
  - 부상 선수 복귀가 최대 변수
- **국가대표 축구 평가전 전망**
  - 신예 선수 기용, 세대 교체 본격화
  - 감독 교체설 관련 루머 해명

---

### 팬 Q&A

**Q. 야구 경기에서 ‘9회말 역전’이 주는 의미는?**  
A. 경기 종료 직전까지 긴장감 유지, 최고의 명승부 연출의 상징입니다.

**Q. 김민재 선수는 최근 유럽 리그에서 어떻게 활약하나요?**  
A. 강력한 수비력과 빌드업 능력으로 팀의 핵심 역할을 하고 있습니다.

---

더 많은 하이라이트는 TV 다시보기 메뉴에서 확인해보세요!
",

@"
# 📰 오늘의 주요 뉴스와 해설

**TV 뉴스 요약과 각 이슈별 해설을 한눈에!**

---

## 🔎 헤드라인 브리핑

1. **국내외 경제 동향**
   - 원/달러 환율 1,380원 돌파, 수출 기업 영향 전망
   - 소비자 물가 상승률 2개월 연속 둔화세
2. **AI 규제·활용 논란**
   - “AI 윤리법” 내년 시행 앞두고 업계 의견 분분
   - 국내 기업, AI 기반 의료 진단 서비스 상용화 추진
3. **환경·기후 이슈**
   - 서울, 7월 중 역대 최장 폭염 기록
   - 유럽 전역에서 ‘탄소세’ 도입 가속화

---

| 분야       | 요약 키워드      | 세부 설명                       |
|------------|------------------|---------------------------------|
| 경제       | 환율·물가        | 수출기업과 서민가계 모두 주목   |
| IT/AI      | 규제·윤리        | 기술 발전과 법적 쟁점 병행      |
| 환경       | 폭염·탄소세      | 이상기후·정책 변화 이슈화       |

---

> ""빠르게 변하는 세상, TV로 핵심만 골라 확인하세요.""

---

## 📺 오늘의 심층 해설

**Q. 최근 AI 규제 논의, 우리 생활에 어떤 영향이 있나요?**  
A. 개인정보 보호, 서비스 추천 등 일상 속 AI 서비스가 더 ‘투명하게’ 관리될 전망입니다.

**Q. 폭염에 대비하는 생활 팁은?**  
A. 실내 온도 26~28도 유지, 냉방기 사용 시 환기 필수, 수분 보충도 잊지 마세요.

---

더 궁금한 뉴스, 리모컨 마이크에 “오늘 뉴스 자세히 알려줘”라고 말해보세요!
",

@"
# 🏡 스마트홈 & TV 연동 가이드

최신 TV는 단순 시청을 넘어 집안 기기와 연결해 더 똑똑하게 활용할 수 있습니다.

---

## 📲 스마트홈 연동 예시

- **음성으로 TV 전원/볼륨/채널 조작**
- 스마트폰으로 방송 화면 캡처/녹화
- IoT 센서 연동, TV 자동 ON/OFF(외출·귀가 시)
- 집안 공기질/온도 정보를 TV 화면에서 확인

---

| 연동 기기        | 활용 기능                  | 사용자 추천도 |
|------------------|---------------------------|---------------|
| 스마트 스피커    | 음성 명령, 음악 스트리밍   | ★★★★★        |
| 공기청정기       | 실시간 공기질 TV에 표시    | ★★★★☆        |
| 로봇청소기       | TV에서 지도·상태 확인      | ★★★☆☆        |
| 스마트 전등      | TV와 연동해 무드등 제어    | ★★★★☆        |

---

> “TV가 집안의 중앙 허브 역할을 하면 생활이 더 스마트해집니다.”

---

## 자주 묻는 질문

**Q. 내 스마트폰도 연동 가능한가요?**  
A. 네, 대부분의 스마트TV는 동일 Wi-Fi에서 ‘화면 미러링’, 리모컨 앱 등으로 연동할 수 있습니다.

**Q. TV로 집안 기기를 조작하려면?**  
A. TV 내 ‘스마트홈’ 메뉴에서 등록하면 음성 명령 또는 화면 메뉴로 쉽게 제어 가능합니다.
",

@"
# 💡 TV에서 자주 쓰는 앱 & 추천 기능

스마트TV의 대표 앱과 꼭 써봐야 할 주요 기능을 한눈에 정리했습니다.

---

## 추천 인기 앱

- **YouTube**: 동영상 검색·구독·자막 기능
- **Netflix**: 인기 드라마/영화 자동 추천
- **Wave**: 실시간 TV + VOD 제공
- **Spotify**: 고음질 음악 감상, 재생목록 관리

---

| 앱 이름       | 특징                  | 추가 기능           |
|---------------|----------------------|---------------------|
| YouTube       | 트렌드 영상, 라이브   | 키즈/교육/운동 등   |
| Netflix       | 오리지널 콘텐츠      | 개인 프로필, 자막   |
| Wave          | 지상파 실시간 + OTT  | 스포츠, 시사 등     |
| Spotify       | 맞춤 음악 추천       | TV·스마트폰 연동    |

---

> “앱을 자주 쓰려면 홈 화면에 바로가기를 추가해보세요!”

---

### 📋 꿀팁

- 검색창에서 ‘오늘 인기 콘텐츠’ 입력 시 추천 영상 자동 표시  
- 화면 상단 ‘앱 이동’ 메뉴에서 원하는 앱을 빠르게 찾을 수 있습니다.

",

@"
# 📝 TV 설정 및 오류 해결 FAQ

TV 사용 중 자주 묻는 질문과 해결법을 한 번에 정리했습니다.

---

## 🔧 기본 설정

- 화면 밝기/명암/색감은 ‘화면 설정’ 메뉴에서 조절
- 음향 효과(서라운드/음성 선명도) 켜기  
- Wi-Fi 연결 상태 점검: “설정 > 네트워크”

---

### ⚠️ 오류 & 해결책

| 증상           | 원인                    | 해결 방법                    |
|----------------|-------------------------|------------------------------|
| 전원이 안 켜짐 | 플러그·리모컨 배터리    | 플러그 재연결, 배터리 교체   |
| 소리 안 남     | 음소거·외부기기 문제    | TV·셋톱박스 연결 상태 확인   |
| 앱 실행 오류   | 네트워크/업데이트 문제  | Wi-Fi 재연결, TV 재시작      |
| 화면이 깜빡임  | HDMI·케이블 문제        | 케이블 재장착/교체           |

---

> “문제가 계속된다면 TV 고객센터나 공식 홈페이지의 Q&A도 참고하세요.”

---

## 추가 꿀팁

- TV 소프트웨어를 주기적으로 업데이트하면 새로운 기능과 보안이 개선됩니다.

",

@"
# 🌤️ 주간 날씨와 TV 활용 아이디어

이번 주 전국 날씨와 집에서 TV로 즐길 수 있는 활동을 안내해 드립니다.

---

## 📅 전국 주간 예보

- **월~화:** 전국 맑음, 낮 29~32℃, 야외활동 적기
- **수~목:** 수도권·강원 비, 출근길 우산 필수
- **금~일:** 점차 맑아지며 주말엔 낮 30℃ 내외 예상

---

| 도시     | 월     | 화     | 수     | 목     | 금     | 토     | 일     |
|----------|--------|--------|--------|--------|--------|--------|--------|
| 서울     | 맑음   | 맑음   | 비     | 흐림   | 맑음   | 맑음   | 맑음   |
| 부산     | 맑음   | 맑음   | 흐림   | 흐림   | 비     | 맑음   | 맑음   |
| 광주     | 맑음   | 맑음   | 비     | 맑음   | 맑음   | 맑음   | 맑음   |

---

> “날씨가 안 좋은 날은 집에서 영화나 운동 영상을 TV로 즐겨보세요!”

---

## TV 활용 아이디어

- 집콕 영화·드라마 몰아보기  
- 피트니스/요가 스트리밍  
- 어린이 영어 교육 콘텐츠 함께 보기  
- 기상정보 위젯, 실시간 뉴스 활용
",

@"
# 🎤 TV 음성 인식 & 맞춤 서비스 가이드

음성 명령으로 TV를 더 쉽고 똑똑하게 활용하는 방법을 안내합니다.

---

## 지원 음성 명령 예시

- “채널 7번 틀어줘”
- “오늘 날씨 알려줘”
- “넷플릭스에서 인기 영화 보여줘”
- “화면 밝기 높여줘”

---

| 명령 종류        | 지원 기능              | 사용 팁                |
|------------------|-----------------------|------------------------|
| 채널·앱 실행     | 원하는 앱·채널 바로 이동 | 발음 천천히 또박또박   |
| 정보 검색        | 날씨, 뉴스, 교통 등      | 명령 전 “헤이 TV~” 호출|
| 설정 조정        | 볼륨·밝기·화면모드 등    | 세부 설정도 가능       |
| 추천 받기        | 맞춤 프로그램 안내       | 최근 시청 기반 추천    |

---

> “음성 명령은 리모컨 버튼 또는 TV 마이크에 말하면 작동합니다.”

---

## Q&A

**Q. 음성 인식이 잘 안 될 때는?**  
A. 주변 소음을 줄이고, 마이크에 가까이 말해보세요.

**Q. 맞춤형 추천 서비스는 어떻게 받나요?**  
A. 시청 기록 기반으로 자동 추천되며, ‘맞춤 추천’ 메뉴에서 직접 설정도 가능합니다.

---

새로운 명령어나 기능이 추가되면 TV 공지 또는 앱 업데이트 안내를 참고하세요!
",

        }; // samples


    }
}
