package be.pxl.spring.service;

import javax.persistence.EntityManager;
import javax.transaction.Transactional;

import be.pxl.spring.domain.Session;
import be.pxl.spring.domain.User;

public class SessionService {

	private EntityManager em;
	
	@Transactional
	public Session save(Session session)
	{
		if(session.getSessionId() == 0)
		{
			em.persist(session);
			return session;
		}
		else
		{
			return em.merge(session);
		}
	}
}
