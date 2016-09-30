package be.pxl.spring.model;

import java.sql.Timestamp;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

@Component
@Scope("prototype")
public class Session {

	int sessionId, userId, voiceTime;
	Timestamp startTime, endTime;
	
}
