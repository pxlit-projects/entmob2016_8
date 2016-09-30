package be.pxl.spring.model;

import java.sql.Timestamp;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

@Component
@Scope("prototype")
public class Session {

	public int getUserId() {
		return userId;
	}
	public void setUserId(int userId) {
		this.userId = userId;
	}
	public int getVoiceTime() {
		return voiceTime;
	}
	public void setVoiceTime(int voiceTime) {
		this.voiceTime = voiceTime;
	}
	public Timestamp getStartTime() {
		return startTime;
	}
	public void setStartTime(Timestamp startTime) {
		this.startTime = startTime;
	}
	public Timestamp getEndTime() {
		return endTime;
	}
	public void setEndTime(Timestamp endTime) {
		this.endTime = endTime;
	}
	public int getSessionId() {
		return sessionId;
	}
	int sessionId, userId, voiceTime;
	Timestamp startTime, endTime;
	
}
