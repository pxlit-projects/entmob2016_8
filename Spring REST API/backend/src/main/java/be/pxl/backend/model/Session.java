package be.pxl.backend.model;

import java.sql.Timestamp;

public class Session {
	public int sessionId, userId, voiceTime;
	public Timestamp startTime, endTime;
	
	public int getSessionId() {
		return sessionId;
	}
	public void setSessionId(int sessionId) {
		this.sessionId = sessionId;
	}
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
	
	
	
	
	

}
