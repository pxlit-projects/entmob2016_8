package be.pxl.spring.dao;

import org.springframework.stereotype.Repository;

import be.pxl.spring.model.Session;

@Repository
public class SessionDao {

	public Session getSessionById(int id) {
		// TODO Database aanspreken en Session ophalen
		Session s = new Session();
		s.setVoiceTime(69);
		
		return s;
	}
	public void updateSession(Session s){
		// TODO Database aanspreken en session updaten
	}

}
